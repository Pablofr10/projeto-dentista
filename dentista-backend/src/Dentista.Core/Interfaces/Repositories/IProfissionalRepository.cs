using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.Entities;

namespace Dentista.Core.Interfaces.Repositories
{
    public interface IProfissionalRepository : IBaseRepository
    {
        Task<IEnumerable<Profissional>> Get();
        Task<Profissional> Get(int idProfissional);
    }
}