using System.Threading.Tasks;
using Dentista.Core.DTOs;
using Dentista.Core.DTOs.Request;
using Dentista.Core.Interfaces.Services;
using Dentista.Core.Params;
using Microsoft.AspNetCore.Mvc;

namespace Dentista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalService _service;

        public ProfissionalController(IProfissionalService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfissionais([FromQuery] ProfissionalParams profissionalParams)
        {
            var profissionais = await _service.BuscarProfissionais(profissionalParams);

            if (profissionais != null) return Ok(profissionais);

            return BadRequest();
        }

        [HttpGet("{idProfissional}")]
        public async Task<IActionResult> GetProfissional(int idProfissional)
        {
            var profissional = await _service.BuscarProfissional(idProfissional);

            if (profissional != null) return Ok(profissional);

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> PutProfissional(ProfissionalRequest profissional)
        {
            var profissionalAdicionado = await _service.AdicionarProfissional(profissional);

            return profissionalAdicionado
                ? Ok("Profissional adicionado")
                : BadRequest("Erro ao atualizar profissional");
        }

        [HttpPut("{idProfissional}")]
        public async Task<IActionResult> PutProfissional(int idProfissional, ProfissionalDto profissional)
        {
            var profissionalAtualizado = await _service.AtualizarProfissional(idProfissional, profissional);

            return profissionalAtualizado
                ? Ok("Profissional atualizado")
                : BadRequest("Erro ao atualizar profissional");
        }
    }
}