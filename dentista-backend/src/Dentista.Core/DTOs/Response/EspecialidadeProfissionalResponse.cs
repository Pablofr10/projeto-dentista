using System;
using System.Collections.Generic;

namespace Dentista.Core.DTOs.Response
{
    public class EspecialidadeProfissionalResponse : BaseDto
    {
        public string Nome { get; set; }
        public bool Ativa { get; set; }
        public List<ProfissionalResponse> Profissionais { get; set; }
    }
}