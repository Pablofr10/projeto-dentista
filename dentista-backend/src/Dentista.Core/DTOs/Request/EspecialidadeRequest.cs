using System;
using System.Collections.Generic;

namespace Dentista.Core.DTOs.Request
{
    public class EspecialidadeRequest
    {
        public int ProfissionalId { get; set; }
        public List<int> Especialidades { get; set; }
        public bool Status { get; set; }
    }
}