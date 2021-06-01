using System;

namespace Dentista.Core.Entities
{
    public class Consulta : Base
    {
        public DateTime DataConsulta { get; set; }
        public DateTime CriadoEm { get; set; }
        public int Status { get; set; }
        public int PagamentoId { get; set; }
        public Pagamento Pagamento { get; set; }
        public int ProcedimentoId { get; set; }
        public Especialidade Especialidade { get; set; }
        public int EspecialidadeId { get; set; }
        public Profissional Profissional { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}