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
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        private readonly string _connectionString;
        public TipoDocumentoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<TipoDocumento>> listarTipoDocumento()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LAVADOACTIVO_TIPO_DOCUMENTO_LISTAR", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var response = new List<TipoDocumento>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToTipoDocumento(reader));
                        }
                    }

                    return response;
                }
            }
        }

        public async Task actualizarTipoDocumento(TipoDocumento tipoDocumento)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LAVADOACTIVO_TIPO_DOCUMENTO_ACTUALIZAR", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@tipo_documento_id", tipoDocumento.tipo_documento_id));
                    cmd.Parameters.Add(new SqlParameter("@ponderacion", tipoDocumento.ponderacion));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

        private TipoDocumento MapToTipoDocumento(SqlDataReader reader)
        {
            return new TipoDocumento()
            {
                tipo_documento_id = (int)reader["tipo_documento_id"],
                subfactor_id = (int)reader["subfactor_id"],
                subfactor = reader["subfactor"].ToString(),
                descripcion = reader["descripcion"].ToString(),
                ponderacion = reader["ponderacion"].ToString()
            };
        }
    }
}
