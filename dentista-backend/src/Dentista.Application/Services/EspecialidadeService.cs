using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.DTOs.Request;
using Dentista.Core.DTOs.Response;
using Dentista.Core.Interfaces.Services;

namespace Dentista.Application.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        public Task<IEnumerable<EspecialidadeResponse>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<EspecialidadeResponse> Get(int idEspecialidade)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Post(EspecialidadeRequest especialidadeRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}