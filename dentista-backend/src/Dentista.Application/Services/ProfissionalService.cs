using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dentista.Core.DTOs;
using Dentista.Core.Interfaces.Repositories;
using Dentista.Core.Interfaces.Services;
using Dentista.Core.Params;

namespace Dentista.Application.Services
{
    public class ProfissionalService : IProfissionalService
    {
        private readonly IMapper _mapper;
        private readonly IProfissionalRepository _repository;

        public ProfissionalService(IProfissionalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProfissionalDto>> BuscarProfissionais(ProfissionalParams profissionalParams)
        {
            var profissionais = await _repository.Get(profissionalParams);

            var profissionaisRetorno = _mapper.Map<IEnumerable<ProfissionalDto>>(profissionais);

            return profissionaisRetorno;
        }

        public async Task<ProfissionalDto> BuscarProfissional(int idProfissional)
        {
            var profissional = await _repository.Get(idProfissional);

            var profissionalRetorno = _mapper.Map<ProfissionalDto>(profissional);

            return profissionalRetorno;
        }

        public Task<bool> AdicionarProfissional(ProfissionalDto profissional)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AtualizarProfissional(int idProfissional, ProfissionalDto profissional)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AdicionarEspecialidade(EspecialidadeDto profissional)
        {
            throw new NotImplementedException();
        }
    }
}