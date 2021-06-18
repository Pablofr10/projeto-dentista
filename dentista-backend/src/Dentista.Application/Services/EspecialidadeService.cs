using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dentista.Core.DTOs.Request;
using Dentista.Core.DTOs.Response;
using Dentista.Core.Interfaces.Repositories;
using Dentista.Core.Interfaces.Services;
using Dentista.Core.Params;

namespace Dentista.Application.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly IEspecialidadeRepository _repository;
        private readonly IMapper _mapper;

        public EspecialidadeService(IEspecialidadeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EspecialidadeResponse>> Get(EspecialidadeParams especialidadeParams)
        {
            var especilidades = await _repository.Get(especialidadeParams);

            if (!especilidades.Any()) return null;

            var especialidadeRetorno = _mapper.Map<IEnumerable<EspecialidadeResponse>>(especilidades);

            return especialidadeRetorno;
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