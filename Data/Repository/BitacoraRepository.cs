using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavadoActivosApi.Data.Interface;
using Microsoft.Extensions.Configuration;
using LavadoActivosApi.Models;
using System.Data.SqlClient;

namespace LavadoActivosApi.Data.Repository
{
    public class BitacoraRepository : IBitacoraRepository
    {
        private readonly string _connectionString;
        public BitacoraRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }
        public async Task<string> InsertarBitacora(Bitacora bitacora)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("sp_MoneyL_InsertBitacora", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nidUserEmi", bitacora.nidUserEmi));
                    cmd.Parameters.Add(new SqlParameter("@nidPerfilEmi", bitacora.nidPerfilEmi));
                    cmd.Parameters.Add(new SqlParameter("@nidUserRecep", bitacora.nidUserRecep));
                    cmd.Parameters.Add(new SqlParameter("@nidPerfilRecep", bitacora.nidPerfilRecep));
                    cmd.Parameters.Add(new SqlParameter("@id_action", bitacora.id_action));
                    cmd.Parameters.Add(new SqlParameter("@obs_bta", bitacora.obs_bta));
                    cmd.Parameters.Add(new SqlParameter("@id_resolution", bitacora.id_resolution));
                    cmd.Parameters.Add(new SqlParameter("@ncaso", bitacora.ncaso));
                    cmd.Parameters.Add(new SqlParameter("@statusCaso", bitacora.statusCaso));

                    string response = null;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToInsertarBitacora(reader);
                        }
                    }
                    return response;
                }
            }

        }
        public async Task<List<BitacoraList>> ListarBitacora(int ncaso)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_MoneyL_ListaBitacora", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ncaso", ncaso));

                    var response = new List<BitacoraList>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MaptoBitacoraList(reader));
                        }
                    }
                    return response;
                }
            }
        }

        private BitacoraList MaptoBitacoraList(SqlDataReader reader)
        {
            return new BitacoraList()
            {
                nidUserEmi = (int)reader["nidUserEmi"],
                emisor = reader["emisor"].ToString(),
                nidUserRecep = (int)reader["nidUserRecep"],
                receptor = reader["receptor"].ToString(),
                rol = reader["rol"].ToString(),
                fecha = reader["fecha"].ToString(),
                hora = reader["hora"].ToString(),
                desc_action = reader["desc_action"].ToString(),
                obs_bta = reader["obs_bta"].ToString(),
                id_resolution = (int)reader["id_resolution"],
                desc_resolution = reader["desc_resolution"].ToString(),
                ncaso = (int)reader["ncaso"],
                userJob = (int)reader["userJob"],
                perfilJob = (int)reader["perfilJob"],
                fAsig = (int)reader["fAsig"],
                userAnt = (int)reader["userAnt"],
                nombreAnt = reader["nombreAnt"].ToString(),
                perfilAnt = (int)reader["perfilAnt"],
                resolAnt = (int)reader["resolAnt"],
                userAna1 = (int)reader["userAna1"],
                nombreAna1 = reader["nombreAna1"].ToString(),
                idBitacora = (int)reader["idBitacora"],
                idBitacoraResp = (int)reader["idBitacoraResp"],
                statusCase = (int)reader["statusCase"]
            };
        }

        private string MapToInsertarBitacora(SqlDataReader reader)
        {
            string response = "";
            response = reader["respuesta"].ToString();
            return response;
        }
    }
}
