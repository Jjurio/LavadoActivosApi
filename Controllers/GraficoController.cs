using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavadoActivosApi.Data.Interface;

namespace LavadoActivosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GraficoController : Controller
    {
        private readonly IGraficoRepository _repository;

        public GraficoController(IGraficoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("GraficoFrecuencia")]
        public async Task<IActionResult> GraficoFrecuencia(string pResolutionType, string pAnhos)
        {
            try
            {
                var respuesta = await _repository.GraficoFrecuencia(pResolutionType, pAnhos);
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
        [HttpGet("GraficoImporte")]
        public async Task<IActionResult> GraficoImporte(string pResolutionType, string pAnhos)
        {
            try
            {
                var reporte = await _repository.GraficoImporte(pResolutionType, pAnhos);
                if (reporte.Length == 0 || reporte == null)
                {
                    return Ok(new
                    {
                        IsSuccess = false,
                        Message = "No se encontraron registros",
                        total = 0,
                        data = reporte
                    });
                }
                return Ok(new
                {
                    IsSuccess = true,
                    Message = "Se listo satisfactoriamente",
                    data = reporte
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: { ex }");
            }
        }
    }
}
