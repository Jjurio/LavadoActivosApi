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
    public class CondicionClienteRepository : ICondicionClienteRepository
    {
        private readonly string _connectionString;
        public CondicionClienteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<CondicionCliente>> listarCondicionCliente()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LAVADOACTIVO_CONDICION_CLIENTE_LISTAR", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var response = new List<CondicionCliente>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToCondicionCliente(reader));
                        }
                    }

                    return response;
                }
            }
        }

        private CondicionCliente MapToCondicionCliente(SqlDataReader reader)
        {
            return new CondicionCliente()
            {
                condicion_cliente_id = (int)reader["condicion_cliente_id"],
                descripcion = reader["descripcion"].ToString(),
                tipo_ponderacion_id = (int)reader["tipo_ponderacion_id"],
                tipo_ponderacion = reader["tipo_ponderacion"].ToString(),
                ponderacion = reader["ponderacion"].ToString()

            };
        }
    }
}
