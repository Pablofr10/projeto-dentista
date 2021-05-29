using Dentista.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dentista.Infrastructure.Maps
{
    public class ConsultaMap : BaseMap<Consulta>
    {
        public ConsultaMap() : base("tb_consulta")
        {}

        public override void Configure(EntityTypeBuilder<Consulta> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Status).HasColumnName("status").HasMaxLength(1).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").IsRequired();

            builder.Property(x => x.ProfissionalId).HasColumnName("id_profissional").IsRequired();
            builder.HasOne(x => x.Profissional).WithMany().HasForeignKey(x => x.ProfissionalId);
            
            builder.Property(x => x.ProcedimentoId).HasColumnName("id_procedimento").IsRequired();
            builder.HasOne(x => x.Procedimento).WithMany().HasForeignKey(x => x.ProcedimentoId);
        }
    }
}