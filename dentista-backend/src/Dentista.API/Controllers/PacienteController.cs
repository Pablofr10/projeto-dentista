using System.Threading.Tasks;
using Dentista.Core.DTOs;
using Dentista.Core.Interfaces.Services;
using Dentista.Core.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentista.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _service;

        public PacienteController(IPacienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPacientes([FromQuery] PacienteParams pacienteParams)
        {
            var pacientes = await _service.BuscarPacientes(pacienteParams);

            if (pacientes == null) return NotFound();

            return Ok(pacientes);
        }

        [HttpGet("{idPaciente}")]
        public async Task<IActionResult> GetPaciente(int idPaciente)
        {
            var paciente = await _service.BuscarPacientePorId(idPaciente);

            if (paciente == null) return NotFound();

            return Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> PostPaciente(PacienteDto paciente)
        {
            var isPacienteAdicionado = await _service.AdicionarPaciente(paciente);

            if (isPacienteAdicionado) return Ok("Paciente criado.");

            return BadRequest("Erro ao criar o paciente.");
        }

        [HttpPut("{idPaciente}")]
        public async Task<IActionResult> PostPaciente(int idPaciente, PacienteDto paciente)
        {
            var isPacienteAdicionado = await _service.AtualizarPaciente(idPaciente, paciente);

            if (isPacienteAdicionado) return Ok("Paciente Atualizado.");

            return BadRequest("Erro ao Atualizado o paciente.");
        }

        [HttpPut("desativar/{idPaciente}")]
        public async Task<IActionResult> DesativarPaciente(int idPaciente)
        {
            var isPacienteAdicionado = await _service.MudarStatusPaciente(idPaciente, false);

            if (isPacienteAdicionado) return Ok("Paciente Desativado.");

            return BadRequest("Erro ao Desativar o paciente.");
        }

        [HttpPut("ativar/{idPaciente}")]
        public async Task<IActionResult> MudarStatusPaciente(int idPaciente)
        {
            var isPacienteAdicionado = await _service.MudarStatusPaciente(idPaciente, true);

            if (isPacienteAdicionado) return Ok("Paciente Ativado.");

            return BadRequest("Erro ao Ativar o paciente.");
        }
    }
}