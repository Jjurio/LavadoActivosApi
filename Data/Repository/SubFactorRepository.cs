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
    public class SubFactorRepository : ISubFactorRepository
    {
        private readonly string _connectionString;
        public SubFactorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<SubFactor>> listarSubFactor()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LAVADOACTIVO_SUBFACTOR_LISTAR", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var response = new List<SubFactor>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToSubFactor(reader));
                        }
                    }

                    return response;
                }
            }
        }

        private SubFactor MapToSubFactor(SqlDataReader reader)
        {
            return new SubFactor()
            {
                subfactor_id = (int)reader["subfactor_id"],
                factor_id = (int)reader["factor_id"],
                factor = reader["factor"].ToString(),
                tipo_ponderacion_id = (int)reader["tipo_ponderacion_id"],
                tipo_ponderacion = reader["tipo_ponderacion"].ToString(),
                url = reader["url"].ToString(),
                descripcion = reader["descripcion"].ToString()
            };
        }
    }
}
