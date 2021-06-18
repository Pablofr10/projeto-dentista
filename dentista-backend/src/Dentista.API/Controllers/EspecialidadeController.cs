using System.Threading.Tasks;
using Dentista.Core.Interfaces.Services;
using Dentista.Core.Params;
using Microsoft.AspNetCore.Mvc;

namespace Dentista.API.Controllers
{
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
        public async Task<IActionResult> GetProfissionais([FromQuery] EspecialidadeParams especialidadeParams)
        {
            var especialidades = await _service.Get(especialidadeParams);

            if (especialidades == null) return NotFound("Nenhuma especialidade encontrada");

            return Ok(especialidades);
        }
    }
}