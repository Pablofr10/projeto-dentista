using System;

namespace Dentista.Core.Entities
{
    public class Consulta : Base
    {
        public DateTime DataConsulta { get; set; }
        public string NomeDentista { get; set; }
        public DateTime CriadoEm { get; set; }
        public int Status { get; set; }
        public decimal Preco { get; set; }
        public int ProcedimentoId { get; set; }
        public Procedimento Procedimento { get; set; }
        public int ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }
        
    }
}