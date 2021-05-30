using System.Threading.Tasks;
using Dentista.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dentista.API.Controllers
{
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
        public async Task<IActionResult> GetPacientes()
        {
            var pacientes = await _service.BuscarPacientes();
            
            if (pacientes != null)
            {
                return Ok(pacientes);
            }
            
            return BadRequest();
        }
        
        [HttpGet("{idPaciente}")]
        public async Task<IActionResult> GetPacientes(int idPaciente)
        {
            var paciente = await _service.BuscarPacientePorId(idPaciente);
            
            if (paciente != null)
            {
                return Ok(paciente);
            }
            
            return BadRequest();
        }
    }
}