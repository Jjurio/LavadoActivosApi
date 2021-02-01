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

        public async Task<List<BitacoraList>> ListarBitacora(int idAlerta)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LAVADOACTIVO_BITACORA_LISTAR", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idAlerta", idAlerta));

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

        public async Task<Bitacora> TraerBitacora(int idAlerta)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LAVADOACTIVO_BITACORA_TRAER", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idAlerta", idAlerta));

                    var response = new Bitacora();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MaptoBitacora(reader);
                        }
                    }
                    return response;
                }
            }
        }

        public async Task<Alerta> InsertarBitacora(Bitacora bitacora)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("sp_LAVADOACTIVO_BITACORA_INSERTAR", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idAlerta", bitacora.idAlerta));
                    cmd.Parameters.Add(new SqlParameter("@nidUserEmi", bitacora.nidUserEmi));
                    cmd.Parameters.Add(new SqlParameter("@nidUserRecep", bitacora.nidUserRecep));
                    cmd.Parameters.Add(new SqlParameter("@id_action", bitacora.id_action));
                    cmd.Parameters.Add(new SqlParameter("@obs_bta", bitacora.obs_bta));
                    cmd.Parameters.Add(new SqlParameter("@id_resolution", bitacora.id_resolution));
                    cmd.Parameters.Add(new SqlParameter("@statusCaso", bitacora.statusCaso));

                    var response = new Alerta();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MaptoAlerta(reader);
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
                idBitacora = (int)reader["idBitacora"],
                idAlerta = (int)reader["idAlerta"],
                nidUserEmi = (int)reader["nidUserEmi"],
                emisor = reader["emisor"].ToString(),
                perfilEmisor = reader["perfilEmisor"].ToString(),
                nidUserRecep = (int)reader["nidUserRecep"],
                fecha = reader["fecha"].ToString(),
                hora = reader["hora"].ToString(),
                id_action = (int)reader["id_action"],
                desc_action = reader["desc_action"].ToString(),
                obs_bta = reader["obs_bta"].ToString(),
                id_resolution = (int)reader["id_resolution"],
                desc_resolution = reader["desc_resolution"].ToString(),
            };
        }

        private Bitacora MaptoBitacora(SqlDataReader reader)
        {
            return new Bitacora()
            {
                idBitacora = (int)reader["idBitacora"],
                idAlerta = (int)reader["idAlerta"],
                nidUserEmi = (int)reader["nidUserEmi"],
                emisor = reader["emisor"].ToString(),
                nidUserRecep = (int)reader["nidUserRecep"],
                id_action = (int)reader["id_action"],
                obs_bta = reader["obs_bta"].ToString(),
                id_resolution = (int)reader["id_resolution"],
                desc_resolution = reader["desc_resolution"].ToString(),
            };
        }

        private Alerta MaptoAlerta(SqlDataReader reader)
        {
            return new Alerta()
            {
                customerID = (int)reader["customerID"],
                code = reader["code"].ToString(),
                description = reader["description"].ToString(),
                id = reader["id"].ToString(),
                reportNumber = reader["reportNumber"].ToString(),
                rosNumber = reader["rosNumber"].ToString(),
                reportDate = reader["reportDate"].ToString(),
                status = reader["status"].ToString(),
            };
        }

    }
}
