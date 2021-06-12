using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dentista.Core.DTOs;
using Dentista.Core.Interfaces.Repositories;
using Dentista.Core.Interfaces.Services;

namespace Dentista.Application.Services
{
    public class ProfissionalService : IProfissionalService
    {
        private readonly IProfissionalRepository _repository;
        private readonly IMapper _mapper;

        public ProfissionalService(IProfissionalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProfissionalDto>> BuscarProfissionais()
        {
            var profissionais = await _repository.Get();

            var profissionaisRetorno = _mapper.Map<IEnumerable<ProfissionalDto>>(profissionais);

            return profissionaisRetorno;
        }

        public Task<ProfissionalDto> BuscarProfissional(int idProfissional)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AdicionarProfissional(ProfissionalDto profissional)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AtualizarProfissional(int idProfissional, ProfissionalDto profissional)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AdicionarEspecialidade(EspecialidadeDto profissional)
        {
            throw new System.NotImplementedException();
        }
    }
}