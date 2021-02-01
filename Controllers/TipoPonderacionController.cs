﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavadoActivosApi.Data.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LavadoActivosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TipoPonderacionController : ControllerBase
    {
        private readonly ITipoPonderacionRepository _repository;
        public TipoPonderacionController(ITipoPonderacionRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> listarTipoPonderacion()
        {
            try
            {
                var resp = await _repository.listarTipoPonderacion();
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
    }
}