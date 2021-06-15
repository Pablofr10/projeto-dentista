using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.Entities;
using Dentista.Core.Params;

namespace Dentista.Core.Interfaces.Repositories
{
    public interface IProfissionalRepository : IBaseRepository
    {
        Task<IEnumerable<Profissional>> Get(ProfissionalParams profissionalParams);
        Task<Profissional> Get(int idProfissional);
        Task<IEnumerable<EspecialidadeProfissional>> GetEspecialidades(int idProfissional);
    }
}