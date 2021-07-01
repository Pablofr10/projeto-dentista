﻿using System.Threading.Tasks;
using Dentista.Core.DTOs.Request;
using Dentista.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dentista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _service;

        public AutenticacaoController(IAutenticacaoService service)
        {
            _service = service;
        }
        
        [Route("/cadastrar")]
        [HttpPost]
        public async Task<IActionResult> Registro(RegistroRequest registro)
        {
            var isRegistrado = await _service.Registro(registro);
            if (isRegistrado == null) return BadRequest("Erro ao gravar o usuário, verifique os dados");

            return Ok("Usuário registrado com sucesso");
        }
    }
}