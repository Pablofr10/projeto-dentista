using System;

namespace Dentista.Core.Entities
{
    public class Pagamento : Base
    {
        public decimal Preco { get; set; }
        public DateTime PagoEm { get; set; }
        public int Status { get; set; }
        public int FormaPagamento { get; set; }
    }
}