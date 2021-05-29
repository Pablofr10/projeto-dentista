using Dentista.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dentista.Infrastructure.Maps
{
    public class EspecialidadeMap : BaseMap<Especialidade>
    {
        public EspecialidadeMap() : base("tb_especialidade")
        {}

        public override void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Ativa).HasColumnName("ativa").IsRequired();
        }
    }
}