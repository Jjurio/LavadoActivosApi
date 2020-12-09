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
    public class PaisRepository : IPaisRepository
    {
        private readonly string _connectionString;
        public PaisRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }
        public async Task<List<PaisList>> ListarPais()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_MoneyL_ListaPais", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var response = new List<PaisList>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MaptoPaisList(reader));
                        }
                    }
                    return response;
                }
            }
        }

        private PaisList MaptoPaisList(SqlDataReader reader)
        {
            return new PaisList()
            {
                countryID = (int)reader["countryID"],
                code = (int)reader["code"],
                abbreviation1 = reader["abbreviation1"].ToString(),
                abbreviation2 = reader["abbreviation2"].ToString(),
                name=reader["name"].ToString()
            };
        }
    }
}
