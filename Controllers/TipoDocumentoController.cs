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
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumentoRepository _repository;
        public TipoDocumentoController(ITipoDocumentoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> listarTipoDocumento()
        {
            try
            {
                var resp = await _repository.listarTipoDocumento();
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

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> actualizarTipoDocumento([FromBody] TipoDocumento tipoDocumento, int id)
        {
            try
            {
                if (tipoDocumento.tipo_documento_id == id)
                {
                    await _repository.actualizarTipoDocumento(tipoDocumento);
                    return Ok(new
                    {
                        IsSuccess = true,
                        Message = "Tipo documento actualizado correctamente",
                    });

                }
                return BadRequest(new { IsSuccess = false, mensaje = "El id no corresponde al tipo documento" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: { ex }");
            }
        }
    }
}