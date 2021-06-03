using System;
using System.Collections.Generic;
using Dentista.Core.Entities;

namespace Dentista.Application.Request
{
    public class ConsultaRequest
    {
        public DateTime DataConsulta { get; set; }
        public int Status { get; set; }
        public int PagamentoId { get; set; }
        public List<int> Especialidades { get; set; }
        public int ProfissionalId { get; set; }
        public int PacienteId { get; set; }
    }
}