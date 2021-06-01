using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dentista.Core.DTOs;
using Dentista.Core.Interfaces.Repositories;
using Dentista.Core.Interfaces.Services;

namespace Dentista.Application.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IMapper _mapper;
        private readonly IConsultaRepository _repository;

        public ConsultaService(IConsultaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConsultaDto>> BuscarConsultas()
        {
            var consultas = await _repository.BuscarConsultas();

            var consultasRetorno = _mapper.Map<IEnumerable<ConsultaDto>>(consultas);

            return consultasRetorno;
        }

        public async Task<ConsultaDto> BuscarConsulta(int idPaciente)
        {
            var consulta = await _repository.BuscarConsulta(idPaciente);

            var consultaRetorno = _mapper.Map<ConsultaDto>(consulta);

            return consultaRetorno;
        }

        public Task<bool> MarcarConsulta()
        {
            throw new NotImplementedException();
        }

        public Task<bool> AtualizarConsulta()
        {
            throw new NotImplementedException();
        }
    }
}