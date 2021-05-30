using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dentista.Application.Response;
using Dentista.Core.DTOs;
using Dentista.Core.Entities;
using Dentista.Core.Interfaces.Repositories;
using Dentista.Core.Interfaces.Services;

namespace Dentista.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repository;
        private readonly IMapper _mapper;

        public PacienteService(IPacienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PacienteDto>> BuscarPacientes()
        {
            var pacientes = await _repository.Get();

            var pacientesRetorno= _mapper.Map<List<PacienteDto>>(pacientes);

            return pacientesRetorno;
        }

        public async Task<PacienteDto> BuscarPacientePorId(int idPaciente)
        {
            var paciente = await _repository.Get(idPaciente);

            var pacienteRetorno = _mapper.Map<PacienteDto>(paciente);

            return pacienteRetorno;
        }

        public Task<bool> AdicionarPaciente(Paciente paciente)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AtualizarPaciente(Paciente paciente)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeletarPaciente(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}