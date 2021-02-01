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
    public class TipoPonderacionRepository : ITipoPonderacionRepository
    {
        private readonly string _connectionString;
        public TipoPonderacionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<TipoPonderacion>> listarTipoPonderacion()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LAVADOACTIVO_TIPO_PONDERACION_LISTAR", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var response = new List<TipoPonderacion>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToTipoPonderacion(reader));
                        }
                    }

                    return response;
                }
            }
        }

        private TipoPonderacion MapToTipoPonderacion(SqlDataReader reader)
        {
            return new TipoPonderacion()
            {
                tipo_ponderacion_id = (int)reader["tipo_ponderacion_id"],
                descripcion = reader["descripcion"].ToString()
            };
        }
    }
}
