using Dentista.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dentista.Infrastructure.Maps
{
    public class PagamentoMap : BaseMap<Pagamento>
    {
        public PagamentoMap() : base("tb_pagamento")
        {}

        public override void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Status).HasColumnName("status").HasMaxLength(2).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(18,2).IsRequired();
            builder.Property(x => x.PagoEm).HasColumnName("pago_em");
            builder.Property(x => x.FormaPagamento).HasColumnName("forma_pagamento").HasMaxLength(50);

        }
    }
}