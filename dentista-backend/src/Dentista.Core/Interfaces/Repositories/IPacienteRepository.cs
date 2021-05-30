using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.Entities;

namespace Dentista.Core.Interfaces.Repositories
{
    public interface IPacienteRepository : IBaseRepository
    {
        Task<IEnumerable<Paciente>> Get();
        Task<Paciente> Get(int idPaciente);
    }
}