using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dentista.Core.DTOs;
using Dentista.Core.DTOs.Request;
using Dentista.Core.Entities;
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

        public async Task<bool> AdicionarProfissional(ProfissionalRequest profissional)
        {
            if (profissional == null) throw new ArgumentException("Profissional vazio");

            var profissionalAdicionar = new Profissional {Nome = profissional.Nome};

            _repository.Add(profissionalAdicionar);

            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> AtualizarProfissional(int idProfissional, ProfissionalDto profissional)
        {
            if (profissional == null) throw new ArgumentException("Profissional não informado");

            var profissionalBanco = await _repository.Get(idProfissional);

            _mapper.Map(profissional, profissionalBanco);

            _repository.Update(profissionalBanco);

            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> AdicionarEspecialidade(int idProfissional, ProfissionalEspecialidadeRequest profissional)
        {
            if (profissional == null) throw new ArgumentException("Nenhuma especialidade informada");

            var especialidadesAdicionar = new List<EspecialidadeProfissional>();

            foreach (var especialidade in profissional.Especialidades)
            {
                var especialidadeAdicionar = new EspecialidadeProfissional
                    {EspecialidadeId = especialidade, ProfissionalId = idProfissional};

                especialidadesAdicionar.Add(especialidadeAdicionar);
            }

            _repository.AddRange(especialidadesAdicionar.ToArray());

            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> AtualizarEspecialidadeProfissional(int idProfissional, ProfissionalEspecialidadeRequest profissional)
        {
            if (profissional == null) throw new ArgumentException("Nenhuma especialidade informada");

            var especialidadesBanco = await _repository.GetEspecialidades(idProfissional);

            var listaAdicionar = new List<EspecialidadeProfissional>();

            foreach (var especialidade in profissional.Especialidades)
                if (!especialidadesBanco.Any(x => x.EspecialidadeId == especialidade))
                {
                    var novaEspecialidade = new EspecialidadeProfissional
                        {EspecialidadeId = especialidade, ProfissionalId = idProfissional};
                    listaAdicionar.Add(novaEspecialidade);
                }

            var listaExcluir = especialidadesBanco.Where(x => !profissional.Especialidades.Contains(x.EspecialidadeId));

            if (listaAdicionar.Count() > 0) _repository.AddRange(listaAdicionar.ToArray());
            if (listaExcluir.Count() > 0) _repository.DeleteRange(listaExcluir.ToArray());


            return await _repository.SaveChangesAsync();
        }
    }
}