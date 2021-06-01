using System.Threading.Tasks;
using AutoMapper;
using Dentista.Core.DTOs;
using Dentista.Core.Interfaces.Repositories;
using Dentista.Core.Interfaces.Services;

namespace Dentista.Application.Services
{
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository _repository;
        private readonly IMapper _mapper;

        public ConsultaService(IConsultaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ConsultaDto> BuscarConsultas()
        {
            var consultas = await _repository.BuscarConsultas();

            var consultasRetorno = _mapper.Map<ConsultaDto>(consultas);

            return consultasRetorno;
        }

        public Task<ConsultaDto> BuscarConsulta()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> MarcarConsulta()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AtualizarConsulta()
        {
            throw new System.NotImplementedException();
        }
    }
}