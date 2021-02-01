using LavadoActivosApi.Data.Interface;
using LavadoActivosApi.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Data.Repository
{
    public class AlertaRepository : IAlertaRepository
    {
        private readonly string _connectionString;
        public AlertaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<Alerta>> ListarAlerta(int usuario_id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LAVADOACTIVO_ALERTA_LISTAR", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@usuario_id", usuario_id));
                    //cmd.Parameters.Add(new SqlParameter("@NroDePagina", NroDePagina));
                    //cmd.Parameters.Add(new SqlParameter("@RegPorPag", RegPorPag));
                    //cmd.Parameters.Add(new SqlParameter("@code", code));
                    //cmd.Parameters.Add(new SqlParameter("@nidPerfil", nidPerfil));

                    var response = new List<Alerta>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MaptoAlerta(reader));
                        }
                    }
                    return response;
                }
            }
        }

        public async Task<Alerta> TraerAlerta(int customerID)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LAVADOACTIVO_ALERTA_TRAER", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@customerID", customerID));

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
