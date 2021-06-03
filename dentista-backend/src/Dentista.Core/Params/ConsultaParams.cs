using System;
using Dentista.Core.Enums;

namespace Dentista.Core.Params
{
    public class ConsultaParams
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public DateTime Data { get; set; }
        public StatusConsulta Status { get; set; }
        public int ProfissionalId { get; set; }
    }
}