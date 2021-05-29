using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.Entities;
using Dentista.Core.Interfaces.Repositories;
using Dentista.Core.Interfaces.Services;

namespace Dentista.Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repository;

        public PacienteService(IPacienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Paciente>> BuscarPacientes()
        {
            var pacientes = await _repository.Get();

            return pacientes;
        }

        public Task<Paciente> BuscarPacientePorId(int idPaciente)
        {
            throw new System.NotImplementedException();
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