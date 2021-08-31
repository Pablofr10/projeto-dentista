using System;
using System.Collections.Generic;
using Dentista.Core.Entities;

namespace Dentista.Core.DTOs
{
    public class ConsultaDto : BaseDto
    {
        public DateTime DataConsulta { get; set; }
        public int Status { get; set; }
        public string NomeStatus => CriaNomeStatus(Status);
        public int PagamentoId { get; set; }
        public Pagamento Pagamento { get; set; }
        public List<string> Especialidades { get; set; }
        public int EspecialidadeId { get; set; }
        public string Profissional { get; set; }
        public string Paciente { get; set; }


        private String CriaNomeStatus(int status)
        {
            string retorno = status switch
            {
                1 => "Marcado",
                2 => "Confirmado",
                3 => "Cancelado",
                _ => "Finalizado",
            };
            return retorno;
        }
    }
}