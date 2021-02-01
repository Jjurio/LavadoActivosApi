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
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;
        public ClienteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<Cliente>> listarClientes(string descripcion, string numero_documento)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LAVADOACTIVO_CLIENTE_LISTAR", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@descripcion", descripcion));
                    cmd.Parameters.Add(new SqlParameter("@numero_documento", numero_documento));

                    var response = new List<Cliente>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToCliente(reader));
                        }
                    }

                    return response;
                }
            }
        }

        public async Task insertarImportCliente(Cliente cliente)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LAVADOACTIVO_IMPORT_CLIENTE_INSERTAR", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@descripcion", cliente.descripcion));
                    cmd.Parameters.Add(new SqlParameter("@tipo_documento", cliente.tipo_documento));
                    cmd.Parameters.Add(new SqlParameter("@numero_documento", cliente.numero_documento));
                    cmd.Parameters.Add(new SqlParameter("@nacionalidad", cliente.nacionalidad));
                    cmd.Parameters.Add(new SqlParameter("@provincia", cliente.provincia));
                    cmd.Parameters.Add(new SqlParameter("@condicion_cliente", cliente.condicion_cliente));
                    cmd.Parameters.Add(new SqlParameter("@tipo_cliente", cliente.tipo_cliente));
                    cmd.Parameters.Add(new SqlParameter("@condicion_juridica", cliente.condicion_juridica));
                    cmd.Parameters.Add(new SqlParameter("@estado_contribuyente", cliente.estado_contribuyente));
                    cmd.Parameters.Add(new SqlParameter("@condicion_tributaria", cliente.condicion_tributaria));
                    cmd.Parameters.Add(new SqlParameter("@condicion_laboral", cliente.condicion_laboral));
                    cmd.Parameters.Add(new SqlParameter("@rango_etario", cliente.rango_etario));
                    cmd.Parameters.Add(new SqlParameter("@antiguedad_cliente", cliente.antiguedad_cliente));
                    cmd.Parameters.Add(new SqlParameter("@antiguedad_juridica", cliente.antiguedad_juridica));
                    cmd.Parameters.Add(new SqlParameter("@tipo_operacion", cliente.tipo_operacion));
                    cmd.Parameters.Add(new SqlParameter("@beneficiario_final", cliente.beneficiario_final));
                    cmd.Parameters.Add(new SqlParameter("@ejecutante", cliente.ejecutante));
                    cmd.Parameters.Add(new SqlParameter("@canal", cliente.canal));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

        public async Task<int> insertarCliente()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LAVADOACTIVO_CLIENTE_INSERTAR", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    int registros_nuevos = 0;
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            registros_nuevos = (int)reader["registros_nuevos"];
                        }
                    }
                    return registros_nuevos;
                }
            }
        }

        private Cliente MapToCliente(SqlDataReader reader)
        {
            return new Cliente()
            {
                cliente_id = (int)reader["cliente_id"],
                empresa_id = (int)reader["empresa_id"],
                descripcion = reader["descripcion"].ToString(),
                tipo_documento = reader["tipo_documento"].ToString(),
                numero_documento = reader["numero_documento"].ToString(),
                nacionalidad = reader["nacionalidad"].ToString()
            };
        }
    }
}
