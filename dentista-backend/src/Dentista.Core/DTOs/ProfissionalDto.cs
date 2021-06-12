using System.Collections.Generic;

namespace Dentista.Core.DTOs
{
    public class ProfissionalDto : BaseDto
    {
        public string Nome { get; set; }
        public List<string> Especialidades { get; set; }
    }
}