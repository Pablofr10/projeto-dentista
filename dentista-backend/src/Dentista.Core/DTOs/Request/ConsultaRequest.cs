using System;
using System.Collections.Generic;
using Dentista.Core.Enums;

namespace Dentista.Core.DTOs.Request
{
    public class ConsultaRequest : BaseDto
    {
        public DateTime DataConsulta { get; set; }
        public StatusConsulta Status { get; set; }
        public PagamentoDto Pagamento { get; set; }
        public int PagamentoId { get; set; }
        public List<int> Especialidades { get; set; }
        public int ProfissionalId { get; set; }
        public int PacienteId { get; set; }
    }
}