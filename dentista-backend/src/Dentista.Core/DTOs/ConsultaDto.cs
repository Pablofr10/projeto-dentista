﻿using System;
using Dentista.Core.Entities;

namespace Dentista.Core.DTOs
{
    public class ConsultaDto : BaseDto
    {
        public DateTime DataConsulta { get; set; }
        public int Status { get; set; }
        public int PagamentoId { get; set; }
        public Pagamento Pagamento { get; set; }
        public string Especialidade { get; set; }
        public int EspecialidadeId { get; set; }
        public string Profissional { get; set; }
        public string Paciente { get; set; }
    }
}