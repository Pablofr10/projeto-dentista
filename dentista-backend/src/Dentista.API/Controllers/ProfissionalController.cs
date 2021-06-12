using System.Threading.Tasks;
using Dentista.Core.Interfaces.Services;
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
        public async Task<IActionResult> GetProfissionais()
        {
            var profissionais = await _service.BuscarProfissionais();

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
    }
}