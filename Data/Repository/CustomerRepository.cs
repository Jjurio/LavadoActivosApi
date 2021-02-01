using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavadoActivosApi.Data.Interface;
using LavadoActivosApi.Models;
using System.Data.SqlClient;

namespace LavadoActivosApi.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;
        public CustomerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }
        public async Task<List<CustomerList>> ListarCustomer()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_MoneyL_ListCustomer", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@NroDePagina", NroDePagina));
                    //cmd.Parameters.Add(new SqlParameter("@RegPorPag", RegPorPag));
                    //cmd.Parameters.Add(new SqlParameter("@code", code));
                    //cmd.Parameters.Add(new SqlParameter("@nidPerfil", nidPerfil));

                    var response = new List<CustomerList>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MaptoListarCustomer(reader));
                        }
                    }
                    return response;
                }
            }
        }
        public async Task<List<CustomerListCase>> ListarCustomerCase(int ncaso)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_MoneyL_ListCustomer_Case", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ncaso", ncaso));

                    var response = new List<CustomerListCase>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MaptoListarCustomerCase(reader));
                        }
                    }
                    return response;
                }
            }
        }
        public async Task<List<CustomerListIOI>> ListarCustomerIOI(int ncaso)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_MoneyL_ListCustomer_IOI", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ncaso", ncaso));

                    var response = new List<CustomerListIOI>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MaptoListarCustomerIOI(reader));
                        }
                    }
                    return response;
                }
            }
        }

        private CustomerList MaptoListarCustomer(SqlDataReader reader)
        {
            return new CustomerList()
            {
                customerID = (int)reader["customerID"],
                code = reader["code"].ToString(),
                description = reader["description"].ToString(),
                id = reader["id"].ToString(),
                reportNumber = reader["reportNumber"].ToString(),
                rosNumber = reader["rosNumber"].ToString(),
                reportDate = reader["reportDate"].ToString(),
                status = reader["status"].ToString(),
                ncaso = (int)reader["ncaso"]
            };
        }
        private CustomerListCase MaptoListarCustomerCase(SqlDataReader reader)
        {
            return new CustomerListCase()
            {
                description = reader["description"].ToString(),
                id = reader["id"].ToString(),
                reportNumber = reader["reportNumber"].ToString(),
                BirthDate = reader["BirthDate"].ToString()
            };
        }
        private CustomerListIOI MaptoListarCustomerIOI(SqlDataReader reader)
        {
            return new CustomerListIOI()
            {
                description = reader["description"].ToString(),
                id = reader["id"].ToString(),
                reportNumber = reader["reportNumber"].ToString()
            };
        }
    }
}
