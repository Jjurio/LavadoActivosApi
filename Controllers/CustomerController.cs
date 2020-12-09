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
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet("ListarCustomer")]
        public async Task<IActionResult> ListarCustomer(int NroDePagina, int RegPorPag, string code, int nidPerfil)
        {
            try
            {

                var resultado = await _repository.ListarCustomer(NroDePagina, RegPorPag, code, nidPerfil);
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
        [HttpGet("ListarCustomerCase")]
        public async Task<IActionResult> ListarCustomerCase(int ncaso)
        {
            try
            {

                var resultado = await _repository.ListarCustomerCase(ncaso);
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
        [HttpGet("ListarCustomerIOI")]
        public async Task<IActionResult> ListarCustomerIOI(int ncaso)
        {
            try
            {

                var resultado = await _repository.ListarCustomerIOI(ncaso);
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
