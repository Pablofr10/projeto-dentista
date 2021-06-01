using System;
using Dentista.Core.Enums;

namespace Dentista.Core.DTOs
{
    public class PagamentoDto : BaseDto
    {
        public decimal Preco { get; set; }
        public DateTime PagoEm { get; set; }
        public StatusPagamento Status { get; set; }
        public string FormaPagamento { get; set; }
    }
}