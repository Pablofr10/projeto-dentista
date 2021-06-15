using System.Threading.Tasks;
using Dentista.Core.DTOs;
using Dentista.Core.DTOs.Request;
using Dentista.Core.Interfaces.Services;
using Dentista.Core.Params;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Dentista.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
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
            var isAdicionado = await _service.AdicionarProfissional(profissional);

            return isAdicionado
                ? Ok("Profissional adicionado")
                : BadRequest("Erro ao atualizar profissional");
        }

        [HttpPut("{idProfissional}")]
        public async Task<IActionResult> PutProfissional(int idProfissional, ProfissionalDto profissional)
        {
            var isAtualizado = await _service.AtualizarProfissional(idProfissional, profissional);

            return isAtualizado
                ? Ok("Profissional atualizado")
                : BadRequest("Erro ao atualizar profissional");
        }
        
        [HttpPost("{idProfissional}/especialidade")]
        public async Task<IActionResult> PutEspecialidade(int idProfissional, EspecialidadeRequest profissional)
        {
            var isAdicionada = await _service.AdicionarEspecialidade(idProfissional, profissional);

            return isAdicionada
                ? Ok("Profissional atualizado")
                : BadRequest("Erro ao atualizar profissional");
        }
        
    }
}