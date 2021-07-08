using System.Threading.Tasks;
using Dentista.Core.DTOs.Request;
using Dentista.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentista.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _service;

        public AutenticacaoController(IAutenticacaoService service)
        {
            _service = service;
        }
        
        [AllowAnonymous]
        [Route("/cadastrar")]
        [HttpPost]
        public async Task<IActionResult> Registro(RegistroRequest registro)
        {
            var isRegistrado = await _service.Registro(registro);
            if (!isRegistrado) return BadRequest("Erro ao gravar o usuário, verifique os dados");

            return Ok("Usuário registrado com sucesso");
        }
        
        [AllowAnonymous]
        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest registro)
        {
            var usuarioLogin = await _service.Login(registro);
            if (usuarioLogin == null) return BadRequest("Erro ao realizar login");

            return Ok(usuarioLogin);
        }
    }
}
