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
    }
}