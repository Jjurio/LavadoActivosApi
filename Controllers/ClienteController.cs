using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavadoActivosApi.Data.Interface;
using LavadoActivosApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LavadoActivosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repository;
        public ClienteController(IClienteRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> listarClientes(string descripcion, string numero_documento)
        {
            try
            {
                var resp = await _repository.listarClientes(descripcion, numero_documento);
                if (resp.Count == 0 || resp == null)
                {
                    return Ok(new
                    {
                        IsSuccess = false,
                        Message = "No se encontraron registros",
                        total = 0,
                        data = resp
                    });
                }
                return Ok(new
                {
                    IsSuccess = true,
                    Message = "Se listo satisfactoriamente",
                    data = resp
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: { ex }");
            }
        }

        [HttpPost("Importar")]
        public async Task<IActionResult> insertarCliente([FromBody] List<Cliente> clientes)
        {
            try
            {
                foreach (Cliente cliente in clientes)
                {
                    if (cliente.nacionalidad != "Nacionalidad") {
                        if (cliente.descripcion == null)
                        {
                            cliente.descripcion = "";
                        }
                        else if (cliente.tipo_documento == null)
                        {
                            cliente.tipo_documento = "";
                        }
                        else if (cliente.numero_documento == null)
                        {
                            cliente.numero_documento = "";
                        }
                        else if (cliente.nacionalidad == null)
                        {
                            cliente.nacionalidad = "";
                        }
                        else if (cliente.provincia == null)
                        {
                            cliente.provincia = "";
                        }
                        else if (cliente.condicion_cliente == null)
                        {
                            cliente.condicion_cliente = "";
                        }
                        else if (cliente.tipo_cliente == null)
                        {
                            cliente.tipo_cliente = "";
                        }
                        else if (cliente.condicion_juridica == null)
                        {
                            cliente.condicion_juridica = "";
                        }
                        else if (cliente.estado_contribuyente == null)
                        {
                            cliente.estado_contribuyente = "";
                        }
                        else if (cliente.condicion_tributaria == null)
                        {
                            cliente.condicion_tributaria = "";
                        }
                        else if (cliente.condicion_laboral == null)
                        {
                            cliente.condicion_laboral = "";
                        }
                        else if (cliente.rango_etario == null)
                        {
                            cliente.rango_etario = "";
                        }
                        else if (cliente.antiguedad_cliente == null)
                        {
                            cliente.antiguedad_cliente = "";
                        }
                        else if (cliente.antiguedad_juridica == null)
                        {
                            cliente.antiguedad_juridica = "";
                        }
                        else if (cliente.tipo_operacion == null)
                        {
                            cliente.tipo_operacion = "";
                        }
                        else if (cliente.beneficiario_final == null)
                        {
                            cliente.beneficiario_final = "";
                        }
                        else if (cliente.ejecutante == null)
                        {
                            cliente.ejecutante = "";
                        }
                        else if (cliente.canal == null)
                        {
                            cliente.canal = "";
                        }

                        await _repository.insertarImportCliente(cliente);
                    }
                }

                var registros_nuevos = await _repository.insertarCliente();

                return Ok(new
                {
                    IsSuccess = true,
                    Message = "Clientes registrado exitosamente",
                    data = registros_nuevos
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: { ex }");
            }

        }
    }
}