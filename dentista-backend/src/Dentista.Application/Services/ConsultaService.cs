using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dentista.Core.DTOs;
using Dentista.Core.DTOs.Request;
using Dentista.Core.Entities;
using Dentista.Core.Enums;
using Dentista.Core.Interfaces.Repositories;
using Dentista.Core.Interfaces.Services;
using Dentista.Core.Params;

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

        public async Task<IEnumerable<ConsultaDto>> BuscarConsultas(ConsultaParams consultaParams)
        {
            var consultas = await _repository.BuscarConsultas(consultaParams);

            var consultasRetorno = _mapper.Map<IEnumerable<ConsultaDto>>(consultas);

            return consultasRetorno;
        }

        public async Task<ConsultaDto> BuscarConsulta(int idConsulta)
        {
            var consulta = await _repository.BuscarConsulta(idConsulta);

            var consultaRetorno = _mapper.Map<ConsultaDto>(consulta);

            return consultaRetorno;
        }

        public async Task<bool> MarcarConsulta(ConsultaRequest consulta)
        {
            if (consulta == null) throw new ArgumentException("Informe os dados para marcar a consulta");

            var consultaGravar = new Consulta
            {
                DataConsulta = consulta.DataConsulta,
                PacienteId = consulta.PacienteId,
                Status = (int) StatusConsulta.Marcado,
                Pagamento = _mapper.Map<Pagamento>(consulta.Pagamento),
                ProfissionalId = consulta.ProfissionalId
            };

            _repository.Add(consultaGravar);

            if (!await _repository.SaveChangesAsync()) return false;
            var especialidades = consulta.Especialidades.Select(especialidade => new ConsultaEspecialidade
                {EspecialidadeId = especialidade, ConsultaId = consultaGravar.Id}).ToList();

            foreach (var especialidade in especialidades) _repository.Add(especialidade);

            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> AtualizarConsulta(int idConsulta, ConsultaRequest consulta)
        {
            if (consulta == null) throw new ArgumentException("Consulta não informada");

            var consultaBanco = await _repository.BuscarConsulta(idConsulta);

            if (consultaBanco == null) throw new ArgumentException("Não existe consulta cadastrada.");

            if (consulta.DataConsulta != DateTime.MinValue) consultaBanco.DataConsulta = consulta.DataConsulta;

            if (consulta.Status > 0) consultaBanco.Status = (int) consulta.Status;

            if (consulta.Pagamento != null) consultaBanco.Pagamento = _mapper.Map<Pagamento>(consulta.Pagamento);

            if (consulta.ProfissionalId > 0) consultaBanco.ProfissionalId = consulta.ProfissionalId;

            _repository.Update(consultaBanco);

            return await _repository.SaveChangesAsync();
        }
    }
}