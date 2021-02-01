﻿using LavadoActivosApi.Data.Interface;
using LavadoActivosApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginRepository _repository;
        public LoginController(ILoginRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {

                var resultado = await _repository.Login(login);
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
