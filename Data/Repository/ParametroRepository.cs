using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LavadoActivosApi.Data.Interface;
using LavadoActivosApi.Models;
using Microsoft.Extensions.Configuration;

namespace LavadoActivosApi.Data.Repository
{
    public class ParametroRepository : IParametroRepository
    {
        private readonly string _connectionString;
        public ParametroRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }
        public async Task<List<ParametroDetalleList>> ListarParametroDetalle(int parameterID)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_MoneyL_ListaParametrosDetalle", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@parameterID", parameterID));


                    var response = new List<ParametroDetalleList>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MaptoListarParametroDetalle(reader));
                        }
                    }
                    return response;
                }
            }
        }

        private ParametroDetalleList MaptoListarParametroDetalle(SqlDataReader reader)
        {
            return new ParametroDetalleList()
            {
                parameterDetailID = (int)reader["parameterDetailID"],
                parameterID = (int)reader["parameterID"],
                subParameterID = (int)reader["subParameterID"],
                description = reader["description"].ToString(),
                status = (int)reader["status"]
            };
        }
    }
}
