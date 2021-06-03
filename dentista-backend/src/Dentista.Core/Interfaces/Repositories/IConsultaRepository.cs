using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.Entities;
using Dentista.Core.Params;

namespace Dentista.Core.Interfaces.Repositories
{
    public interface IConsultaRepository : IBaseRepository
    {
        Task<IEnumerable<Consulta>> BuscarConsultas(ConsultaParams consultaParams);
        Task<Consulta> BuscarConsulta(int idConsulta);
    }
}