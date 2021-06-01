using System.Threading.Tasks;
using Dentista.Core.Interfaces.Services;
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
        public async Task<IActionResult> Get()
        {
            var consultas = await _service.BuscarConsultas();

            if (consultas != null)
            {
                return Ok(consultas);
            }

            return BadRequest("Erro ao obter as consultas");
        }
    }
}