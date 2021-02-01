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

        [HttpGet("Listar")]
        public async Task<IActionResult> ListarBitacora(int idAlerta)
        {
            try
            {

                var resultado = await _repository.ListarBitacora(idAlerta);
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

        [HttpGet("Traer")]
        public async Task<IActionResult> TraerBitacora(int idAlerta)
        {
            try
            {

                var resultado = await _repository.TraerBitacora(idAlerta);
                if (resultado == null)
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


        [HttpPost("Insertar")]
        public async Task<IActionResult> InsertarBitacora([FromBody] Bitacora bitacora)
        {
            try
            {
                var resultado = await _repository.InsertarBitacora(bitacora);
                if (resultado == null)
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
