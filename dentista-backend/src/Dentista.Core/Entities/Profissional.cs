using System.Collections.Generic;

namespace Dentista.Core.Entities
{
    public class Profissional : Base
    {
        public string Nome { get; set; }
        public List<Especialidade> Especialidades { get; set; }
    }
}