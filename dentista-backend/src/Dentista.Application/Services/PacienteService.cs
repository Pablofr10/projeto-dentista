using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.Entities;
using Dentista.Core.Interfaces.Services;

namespace Dentista.Application.Services
{
    public class PacienteService : IPacienteService
    {
        public Task<IEnumerable<Paciente>> BuscarPacientes()
        {
            throw new System.NotImplementedException();
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