using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.Entities;
using Dentista.Core.Params;

namespace Dentista.Core.Interfaces.Repositories
{
    public interface IEspecialidadeRepository : IBaseRepository
    {
        Task<IEnumerable<Especialidade>> Get(EspecialidadeParams especialidadeParams);
        Task<Paciente> Get(int idPaciente);
    }
}