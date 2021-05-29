using System.Collections.Generic;

namespace Dentista.Core.Entities
{
    public class Especialidade : Base
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public List<Profissional> Profissionais { get; set; }
    }
}