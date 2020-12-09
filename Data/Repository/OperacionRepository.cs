using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavadoActivosApi.Data.Interface;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LavadoActivosApi.Data.Repository
{
    public class OperacionRepository : IOperacionRepository
    {
        private readonly string _connectionString;
        public OperacionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<string> OperacionesInusuales(string pOrigenReporte, string pAnhos)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_MoneyL_OperacionesInusuales", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@pOrigenReporte", pOrigenReporte));
                    cmd.Parameters.Add(new SqlParameter("@pAnhos", pAnhos));

                    string response = null;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToOperacionesInusuales(reader);
                        }
                    }

                    return response;
                }
            }
            
        }
        public async Task<string> OperacionesSospechosas(string pOrigenReporte, string pAnhos)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_MoneyL_OperacionesSospechosas", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@pOrigenReporte", pOrigenReporte));
                    cmd.Parameters.Add(new SqlParameter("@pAnhos", pAnhos));

                    string response = null;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToOperacionesSospechosas(reader);
                        }
                    }

                    return response;
                }
            }

        }
        private string MapToOperacionesInusuales(SqlDataReader reader)
        {
            string response = "";
            response = reader["resp"].ToString();
            return response;
        }
        private string MapToOperacionesSospechosas(SqlDataReader reader)
        {
            string response = "";
            response = reader["resp"].ToString();
            return response;
        }
    }
}
