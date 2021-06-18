using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.DTOs.Request;
using Dentista.Core.DTOs.Response;

namespace Dentista.Core.Interfaces.Services
{
    public interface IEspecialidadeService
    {
        Task<IEnumerable<EspecialidadeResponse>> Get();
        Task<EspecialidadeResponse> Get(int idEspecialidade);
        Task<bool> Post(EspecialidadeRequest especialidadeRequest);
    }
}