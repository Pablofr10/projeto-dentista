using System;
using System.Collections.Generic;

namespace Dentista.Core.Entities
{
    public class Consulta : Base
    {
        public DateTime DataConsulta { get; set; }
        public DateTime CriadoEm { get; set; }
        public int Status { get; set; }
        public int PagamentoId { get; set; }
        public Pagamento Pagamento { get; set; }
        public List<Especialidade> Especialidades { get; set; }
        public int ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
    }
}