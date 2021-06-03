using System.Threading.Tasks;
using Dentista.Core.DTOs.Request;
using Dentista.Core.Interfaces.Services;
using Dentista.Core.Params;
using Microsoft.AspNetCore.Mvc;

namespace Dentista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _service;

        public ConsultaController(IConsultaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]ConsultaParams consultaParams)
        {
            var consultas = await _service.BuscarConsultas(consultaParams);

            if (consultas != null) return Ok(consultas);

            return BadRequest("Erro ao obter consultas");
        }

        [HttpGet("{idPaciente}")]
        public async Task<IActionResult> Get(int idPaciente)
        {
            var consulta = await _service.BuscarConsulta(idPaciente);

            if (consulta != null) return Ok(consulta);

            return BadRequest("Erro ao obter consulta");
        }

        [HttpPost]
        public async Task<IActionResult> Post(ConsultaRequest consulta)
        {
            var consultaAdicionada = await _service.MarcarConsulta(consulta);

            return consultaAdicionada ? Ok("Consulta marcada") : BadRequest("Erro ao marcar a consulta");
        }

        [HttpPut("{idConsulta}")]
        public async Task<IActionResult> Put(int idConsulta, ConsultaRequest consulta)
        {
            var consultaAdicionada = await _service.AtualizarConsulta(idConsulta, consulta);

            var consultaRetorno = await _service.BuscarConsulta(idConsulta);

            return consultaAdicionada ? Ok(consultaRetorno) : BadRequest("Erro ao atualizar consulta");
        }
    }
}