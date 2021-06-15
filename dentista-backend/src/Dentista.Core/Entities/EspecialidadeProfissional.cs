using System;

namespace Dentista.Core.Entities
{
    public class EspecialidadeProfissional
    {
        public int ProfissionalId { get; set; }
        public virtual Profissional Profissional { get; set; }
        public int EspecialidadeId { get; set; }
        public virtual Especialidade Especialidade { get; set; }
        public DateTime CriadoEm { get; } = DateTime.Today;
    }
}