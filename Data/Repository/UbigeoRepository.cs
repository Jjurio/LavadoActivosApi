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
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly string _connectionString;
        public UbigeoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }
        public async Task<List<UbigeoList>> ListarUbigeo()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_MoneyL_ListaUbigeo", sql))
                {
                    var response = new List<UbigeoList>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MaptoListarUbigeo(reader));
                        }
                    }
                    return response;
                }
            }
        }
        private UbigeoList MaptoListarUbigeo(SqlDataReader reader)
        {
            return new UbigeoList()
            {
                cDepartamento = reader["cDepartamento"].ToString(),
                cProvincia = reader["cProvincia"].ToString(),
                cDistrito = reader["cDistrito"].ToString(),
                vDescripcion = reader["vDescripcion"].ToString()
            };
        }
    }
}
