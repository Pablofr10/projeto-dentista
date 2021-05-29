using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.Entities;

namespace Dentista.Core.Interfaces.Repositories
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> Get();
        Task<Paciente> Get(int idPaciente);
        Task<bool> Post(Paciente paciente);
        Task<bool> Put(Paciente paciente);
        Task<bool> Delete(int id);
    }
}