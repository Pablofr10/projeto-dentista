using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.Entities;
using Dentista.Core.Params;

namespace Dentista.Core.Interfaces.Repositories
{
    public interface IPacienteRepository : IBaseRepository
    {
        Task<IEnumerable<Paciente>> Get(PacienteParams pacienteParam);
        Task<Paciente> Get(int idPaciente);
    }
}