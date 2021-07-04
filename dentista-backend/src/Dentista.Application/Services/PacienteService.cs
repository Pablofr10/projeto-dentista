using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dentista.Core.DTOs;
using Dentista.Core.Entities;
using Dentista.Core.Interfaces.Repositories;
using Dentista.Core.Interfaces.Services;
using Dentista.Core.Params;

namespace Dentista.API.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IMapper _mapper;
        private readonly IPacienteRepository _repository;

        public PacienteService(IPacienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PacienteDto>> BuscarPacientes(PacienteParams pacienteParams)
        {
            var pacientes = await _repository.Get(pacienteParams);

            var pacientesRetorno = _mapper.Map<List<PacienteDto>>(pacientes);

            return pacientesRetorno;
        }

        public async Task<PacienteDto> BuscarPacientePorId(int idPaciente)
        {
            var paciente = await _repository.Get(idPaciente);

            var pacienteRetorno = _mapper.Map<PacienteDto>(paciente);

            return pacienteRetorno;
        }

        public async Task<bool> AdicionarPaciente(PacienteDto paciente)
        {
            var pacienteAdicionar = _mapper.Map<Paciente>(paciente);
            _repository.Add(pacienteAdicionar);

            if (await _repository.SaveChangesAsync()) return true;

            return false;
        }

        public async Task<bool> AtualizarPaciente(int idPaciente, PacienteDto paciente)
        {
            if (idPaciente < 1) throw new ArgumentException("Informe o paciente para ser atualizado");

            var pacienteBanco = await _repository.Get(idPaciente);

            if (pacienteBanco == null) throw new ArgumentException("Paciente não encontrado");

            _mapper.Map(paciente, pacienteBanco);

            _repository.Update(pacienteBanco);

            if (await _repository.SaveChangesAsync()) return true;

            return false;
        }

        public async Task<bool> MudarStatusPaciente(int idPaciente, bool ativo)
        {
            if (idPaciente < 1) throw new ArgumentException("Paciente não encontrado");

            var paciente = await _repository.Get(idPaciente);

            if (paciente == null) throw new ArgumentException("Paciente não encontrado");

            paciente.Ativo = ativo;

            _repository.Update(paciente);

            if (await _repository.SaveChangesAsync()) return true;

            return false;
        }
    }
}