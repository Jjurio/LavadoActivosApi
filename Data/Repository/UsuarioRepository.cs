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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;
        public UsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }
        public async Task<List<UsuarioList>> ListarUsuario(int idPerfil)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_MoneyL_ListarUsuario", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idPerfil", idPerfil));

                    var response = new List<UsuarioList>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MaptoListarUsuario(reader));
                        }
                    }
                    return response;
                }
            }
        }
        private UsuarioList MaptoListarUsuario(SqlDataReader reader)
        {
            return new UsuarioList()
            {
                nidUser = (int)reader["nidUser"],
                nombre = reader["nombre"].ToString(),
                nidPerfil = (int)reader["nidPerfil"],
                vnombrePerfil = reader["vnombrePerfil"].ToString(),
                nestado = (int)reader["nestado"]
            };
        }
    }
}
