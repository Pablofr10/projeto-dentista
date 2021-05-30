using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.Entities;

namespace Dentista.Core.Interfaces.Repositories
{
    public interface IConsultaRepository : IBaseRepository
    {
        Task<IEnumerable<Consulta>> BuscarConsultas();
        Task<Consulta> BuscarConsulta(int IdPaciente);
    }
}