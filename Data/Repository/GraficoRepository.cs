using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using LavadoActivosApi.Data.Interface;
using System.Data.SqlClient;

namespace LavadoActivosApi.Data.Repository
{
    public class GraficoRepository : IGraficoRepository
    {
        private readonly string _connectionString;
        public GraficoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<string> GraficoFrecuencia(string pResolutionType, string pAnhos)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_MoneyL_GraficoFrecuencia", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@pResolutionType", pResolutionType));
                    cmd.Parameters.Add(new SqlParameter("@pAnhos", pAnhos));

                    string response = null;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToGraficoFrecuencia(reader);
                        }
                    }

                    return response;
                }
            }
        }
        public async Task<string> GraficoImporte(string pResolutionType, string pAnhos)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_MoneyL_GraficoImporte", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@pResolutionType", pResolutionType));
                    cmd.Parameters.Add(new SqlParameter("@pAnhos", pAnhos));

                    string response = null;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToGraficoImporte(reader);
                        }
                    }

                    return response;
                }
            }
        }

        private string MapToGraficoFrecuencia(SqlDataReader reader)
        {
            string response = "";
            response = reader["resp"].ToString();
            return response;
        }
        private string MapToGraficoImporte(SqlDataReader reader)
        {
            string response = "";
            response = reader["resp"].ToString();
            return response;
        }
    }
}
