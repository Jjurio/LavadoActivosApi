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
    public class ExcelController : Controller
    {
        private readonly IExcelRepository _repository;

        public ExcelController(IExcelRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost("InsertarExcel")]
        public async Task<IActionResult> InsertarExcel([FromBody] ExcelClase excelClase)
        {
            try
            {
                await _repository.InsertarExcel(excelClase);
                return Ok(new
                {
                    IsSuccess = true,
                    Message = "Datos registrados exitosamente.",
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: { ex }");
            }

        }
    }
}
