using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.Entities;
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
        public async Task<IEnumerable<Paciente>> GetPacientes()
        {
            var pacientes = await _service.BuscarPacientes();
            return pacientes;
        }
    }
}