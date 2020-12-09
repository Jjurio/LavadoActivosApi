using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavadoActivosApi.Data.Interface;
using LavadoActivosApi.Models;

namespace LavadoActivosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BitacoraController : Controller
    {
        private readonly IBitacoraRepository _repository;
        public BitacoraController(IBitacoraRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpPost("InsertarBitacora")]
        public async Task<IActionResult> InsertarExcel([FromBody] Bitacora bitacora)
        {
            try
            {
                var respuesta = await _repository.InsertarBitacora(bitacora);
                if (respuesta=="true")
                {
                    return Ok(new
                    {
                        IsSuccess = true,
                        Message = "Se insertó correctamente.",
                        data = respuesta
                    });
                }
                else
                {
                    return Ok(new
                    {
                        IsSuccess = false,
                        Message = "Hubo un error en el registro.",
                        total = 0,
                        data = respuesta
                    });
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: { ex }");
            }

        }
        [HttpGet("ListarBitacora")]
        public async Task<IActionResult> ListarBitacora(int ncaso)
        {
            try
            {

                var resultado = await _repository.ListarBitacora(ncaso);
                if (resultado.Count == 0 || resultado == null)
                {
                    return Ok(new
                    {
                        IsSuccess = false,
                        Message = "No se encontraron registros",
                        total = 0,
                        data = resultado
                    });
                }
                return Ok(new
                {
                    IsSuccess = true,
                    Message = "Se listó satisfactoriamente",
                    data = resultado
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: { ex }");
            }
        }
    }
}
