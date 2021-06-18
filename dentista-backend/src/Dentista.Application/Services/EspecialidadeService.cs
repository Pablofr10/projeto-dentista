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
            var especilidades = await _repository.BuscarEspecialidades(especialidadeParams);

            if (!especilidades.Any()) return null;

            var especialidadesRetorno = _mapper.Map<IEnumerable<EspecialidadeResponse>>(especilidades);

            return especialidadesRetorno;
        }

        public async Task<EspecialidadeResponse> Get(int idEspecialidade)
        {
            var especilidade = await _repository.BuscarEspecialidadeProfissionais(idEspecialidade);

            if (especilidade == null) return null;

            var especialidadeRetorno = _mapper.Map<EspecialidadeResponse>(especilidade);

            return especialidadeRetorno;
        }

        public async Task<EspecialidadeProfissionalResponse> BuscarEspecialidadeProfissionais(int idEspecialidade)
        {
            var especilidade = await _repository.BuscarEspecialidadeProfissionais(idEspecialidade);

            if (especilidade == null) return null;

            var especialidadeRetorno = _mapper.Map<EspecialidadeProfissionalResponse>(especilidade);

            return especialidadeRetorno;
        }

        public Task<bool> Post(EspecialidadeRequest especialidadeRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}