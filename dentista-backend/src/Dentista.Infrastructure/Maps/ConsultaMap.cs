using Dentista.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dentista.Infrastructure.Maps
{
    public class ConsultaMap : BaseMap<Consulta>
    {
        public ConsultaMap() : base("tb_consulta")
        {
        }

        public override void Configure(EntityTypeBuilder<Consulta> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Status).HasColumnName("status").HasMaxLength(1).IsRequired();
            builder.Property(x => x.CriadoEm).HasColumnName("criado_em").HasMaxLength(1).IsRequired();
            builder.Property(x => x.DataConsulta).HasColumnName("data_consulta").HasMaxLength(1).IsRequired();

            builder.Property(x => x.PagamentoId).HasColumnName("id_pagamento").IsRequired();
            builder.HasOne(x => x.Pagamento).WithMany().HasForeignKey(x => x.PagamentoId);
            
            builder.Property(x => x.ProfissionalId).HasColumnName("id_profissional").IsRequired();
            builder.HasOne(x => x.Profissional).WithMany().HasForeignKey(x => x.ProfissionalId);
            
            builder.Property(x => x.PacienteId).HasColumnName("id_paciente").IsRequired();
            builder.HasOne(x => x.Paciente).WithMany(g => g.Consultas).HasForeignKey(x => x.PacienteId);

            builder.HasMany(x => x.Especialidades)
                .WithMany(x => x.Consultas)
                .UsingEntity<ConsultaEspecialidade>(
                    x => x.HasOne(p => p.Especialidade).WithMany().HasForeignKey(p => p.EspecialidadeId),
                    x => x.HasOne(p => p.Consulta).WithMany().HasForeignKey(p => p.ConsultaId),
                    x =>
                    {
                        x.ToTable("tb_consulta_especialidade");

                        x.HasKey(p => new {p.EspecialidadeId, p.ConsultaId});

                        x.Property(p => p.EspecialidadeId).HasColumnName("id_especialidade").IsRequired();
                        x.Property(p => p.ConsultaId).HasColumnName("id_consulta").IsRequired();
                    }
                );
        }
    }
}