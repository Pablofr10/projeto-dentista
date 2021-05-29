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
            builder.Property(x => x.CriadoEm).HasColumnName("criado_em").HasMaxLength(1).IsRequired();
            builder.Property(x => x.DataConsulta).HasColumnName("data_consulta").HasMaxLength(1).IsRequired();

            builder.Property(x => x.PacienteId).HasColumnName("id_paciente").IsRequired();
            builder.HasOne(x => x.Paciente).WithMany().HasForeignKey(x => x.PacienteId);
            
            builder.Property(x => x.PagamentoId).HasColumnName("id_pagamento").IsRequired();
            builder.HasOne(x => x.Pagamento).WithMany().HasForeignKey(x => x.PagamentoId);

            builder.Property(x => x.EspecialidadeId).HasColumnName("id_profissional").IsRequired();
            builder.HasOne(x => x.Profissional).WithMany().HasForeignKey(x => x.EspecialidadeId);
            
            builder.Property(x => x.ProcedimentoId).HasColumnName("id_procedimento").IsRequired();
            builder.HasOne(x => x.Especialidade).WithMany().HasForeignKey(x => x.ProcedimentoId);
        }
    }
}