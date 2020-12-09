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
    public class PaisController : Controller
    {
        private readonly IPaisRepository _repository;
        public PaisController(IPaisRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet("ListarPais")]
        public async Task<IActionResult> ListarPais()
        {
            try
            {

                var resultado = await _repository.ListarPais();
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
                    Message = "Se listo satisfactoriamente",
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
