using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.DTOs.Request;
using Dentista.Core.DTOs.Response;
using Dentista.Core.Params;

namespace Dentista.Core.Interfaces.Services
{
    public interface IEspecialidadeService
    {
        Task<IEnumerable<EspecialidadeResponse>> Get(EspecialidadeParams especialidadeParams);
        Task<EspecialidadeResponse> Get(int idEspecialidade);
        Task<bool> Post(EspecialidadeRequest especialidadeRequest);
    }
}