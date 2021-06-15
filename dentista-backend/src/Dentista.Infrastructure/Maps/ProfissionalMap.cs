using Dentista.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dentista.Infrastructure.Maps
{
    public class ProfissionalMap : BaseMap<Profissional>
    {
        public ProfissionalMap() : base("tb_profissional")
        {
        }

        public override void Configure(EntityTypeBuilder<Profissional> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();

            builder.HasMany(x => x.Especialidades)
                .WithMany(x => x.Profissionais)
                .UsingEntity<EspecialidadeProfissional>(
                    x => x.HasOne(p => p.Especialidade).WithMany().HasForeignKey(p => p.EspecialidadeId),
                    x => x.HasOne(p => p.Profissional).WithMany().HasForeignKey(p => p.ProfissionalId),
                    x =>
                    {
                        x.ToTable("tb_profissional_especialidade");

                        x.HasKey(p => new {ProcedimentoId = p.EspecialidadeId, p.ProfissionalId});

                        x.Property(p => p.EspecialidadeId).HasColumnName("id_especialidade").IsRequired();
                        x.Property(p => p.ProfissionalId).HasColumnName("id_profissional").IsRequired();
                        x.Property(p => p.CriadoEm).HasColumnName("criado_em").IsRequired();
                    }
                );
        }
    }
}