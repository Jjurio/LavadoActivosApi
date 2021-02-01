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
    public class FactorRepository : IFactorRepository
    {
        private readonly string _connectionString;
        public FactorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<Factor>> listarFactor()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LAVADOACTIVO_FACTOR_LISTAR", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var response = new List<Factor>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToFactor(reader));
                        }
                    }

                    return response;
                }
            }
        }

        private Factor MapToFactor(SqlDataReader reader)
        {
            return new Factor()
            {
                factor_id = (int)reader["factor_id"],
                descripcion = reader["descripcion"].ToString()
            };
        }
    }
}
