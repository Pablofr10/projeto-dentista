using System;

namespace Dentista.Core.Entities
{
    public class Pagamento : Base
    {
        public decimal Preco { get; set; }
        public DateTime DataPagamento { get; set; }
        public int StatusPagamento { get; set; }
    }
}