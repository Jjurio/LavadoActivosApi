using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavadoActivosApi.Models;
using LavadoActivosApi.Data.Interface;

namespace LavadoActivosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OperacionController : Controller
    {
        private readonly IOperacionRepository _repository;

        public OperacionController(IOperacionRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet("OperacionesInusuales")]
        public async Task<IActionResult> OperacionesInusuales(string pOrigenReporte, string pAnhos)
        {
            try
            {
                var respuesta = await _repository.OperacionesInusuales(pOrigenReporte, pAnhos);
                if (respuesta.Length == 0 || respuesta == null)
                {
                    return Ok(new
                    {
                        IsSuccess = false,
                        Message = "No se encontraron registros",
                        total = 0,
                        data = respuesta
                    });
                }
                return Ok(new
                {
                    IsSuccess = true,
                    Message = "Se listo satisfactoriamente",
                    data = respuesta
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: { ex }");
            }
        }
        [HttpGet("OperacionesSospechosas")]
        public async Task<IActionResult> OperacionesSospechosas(string pOrigenReporte, string pAnhos)
        {
            try
            {
                var respuesta = await _repository.OperacionesSospechosas(pOrigenReporte, pAnhos);
                if (respuesta.Length == 0 || respuesta == null)
                {
                    return Ok(new
                    {
                        IsSuccess = false,
                        Message = "No se encontraron registros",
                        total = 0,
                        data = respuesta
                    });
                }
                return Ok(new
                {
                    IsSuccess = true,
                    Message = "Se listo satisfactoriamente",
                    data = respuesta
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: { ex }");
            }
        }
    }
}
