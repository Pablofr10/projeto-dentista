using System.Threading.Tasks;
using Dentista.Core.DTOs.Request;
using Dentista.Core.Interfaces.Services;
using Dentista.Core.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentista.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeService _service;

        public EspecialidadeController(IEspecialidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] EspecialidadeParams especialidadeParams)
        {
            var especialidades = await _service.Get(especialidadeParams);

            if (especialidades == null) return NotFound("Nenhuma especialidade encontrada");

            return Ok(especialidades);
        }

        [HttpGet("{idEspecialidade}")]
        public async Task<IActionResult> Get(int idEspecialidade)
        {
            var especialidade = await _service.Get(idEspecialidade);

            if (especialidade == null) return NotFound("Especialidade não encontrada");

            return Ok(especialidade);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(EspecialidadeRequest especialidadeParams)
        {
            var isEspecialidade = await _service.AdicionarEspecialidade(especialidadeParams);

            if (!isEspecialidade) return BadRequest("Erro ao adicionar a especialidade.");

            return Ok("Especialidade adicionada");
        }
        
        [HttpPut("{idEspecialidade}")]
        public async Task<IActionResult> Put(int idEspecialidade, EspecialidadeRequest especialidadeParams)
        {
            var isEspecialidade = await _service.AtualizarEspecialidade(idEspecialidade, especialidadeParams);

            if (!isEspecialidade) return BadRequest("Erro ao adicionar a especialidade.");

            return Ok("Especialidade atualizada.");
        }

        [HttpGet("{idEspecialidade}/profissionais")]
        public async Task<IActionResult> GetEspecialidadeProfissionais(int idEspecialidade)
        {
            var especialidade = await _service.BuscarEspecialidadeProfissionais(idEspecialidade);

            if (especialidade == null) return NotFound("Especialidade não encontrada");

            return Ok(especialidade);
        }
    }
}