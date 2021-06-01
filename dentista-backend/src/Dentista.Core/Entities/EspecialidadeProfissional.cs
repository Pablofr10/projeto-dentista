using System;

namespace Dentista.Core.Entities
{
    public class EspecialidadeProfissional
    {
        public int ProfissionalId { get; set; }
        public virtual Profissional Profissional { get; set; }
        public int EspecialidadeId { get; set; }
        public virtual Especialidade Especialidade { get; set; }
        public bool Status { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}