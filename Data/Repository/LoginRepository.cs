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
        public async Task<Login> Login(Login login)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LAVADOACTIVO_USUARIO_LOGIN", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@vuser", login.vuser));
                    cmd.Parameters.Add(new SqlParameter("@vpassword", login.vpassword));

                    var response = new Login();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MaptoLogin(reader);
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
                nidUser = (int)reader["nidUser"],
                nidPerfil = (int)reader["nidPerfil"],
                vuser = reader["vuser"].ToString(),
                perfil = reader["perfil"].ToString(),
                vnombres = reader["vnombres"].ToString(),
                vpaterno = reader["vpaterno"].ToString(),
                vmaterno = reader["vmaterno"].ToString(),
                vemail = reader["vemail"].ToString()
            };
        }
    }
}
