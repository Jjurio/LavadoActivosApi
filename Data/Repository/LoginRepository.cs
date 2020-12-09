using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavadoActivosApi.Data.Interface;
using LavadoActivosApi.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace LavadoActivosApi.Data.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly string _connectionString;
        public LoginRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }
        public async Task<List<Login>> Login(string vUser, string vpassword)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_MoneyL_LoginUser", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@vUser", vUser));
                    cmd.Parameters.Add(new SqlParameter("@vpassword", vpassword));

                    var response = new List<Login>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MaptoLogin(reader));
                        }
                    }
                    return response;
                }
            }
        }
        private Login MaptoLogin(SqlDataReader reader)
        {
            return new Login()
            {
                respuesta = reader["respuesta"].ToString(),
                nidUser = (int)reader["nidUser"],
                vdescripcion = reader["vdescripcion"].ToString(),
                vuser = reader["vuser"].ToString(),
                vnombres = reader["vnombres"].ToString(),
                vpaterno = reader["vpaterno"].ToString(),
                vmaterno = reader["vmaterno"].ToString(),
                vsexo = (int)reader["vsexo"],
                vemail = reader["vemail"].ToString(),
                profdescripcion = reader["profdescripcion"].ToString(),
                nidPerfil = (int)reader["nidPerfil"]
            };
        }
    }
}
