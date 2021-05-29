using Dentista.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dentista.Infrastructure.Maps
{
    public class PacienteMap : BaseMap<Paciente>
    {
        public PacienteMap() : base("tb_paciente")
        {}

        public override void Configure(EntityTypeBuilder<Paciente> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Sexo).HasColumnName("sexo").HasMaxLength(2).IsRequired();
            builder.Property(x => x.Endereco).HasColumnName("endereco").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Cidade).HasColumnName("cidade").HasMaxLength(30).IsRequired();
            builder.Property(x => x.Telefone).HasColumnName("telefone").HasMaxLength(11).IsRequired();
            builder.Property(x => x.Celular).HasColumnName("celular").HasMaxLength(11).IsRequired();
            builder.Property(x => x.CriadoEm).HasColumnName("criado_em").IsRequired();
            builder.Property(x => x.CEP).HasColumnName("cep").HasMaxLength(8).IsRequired();
        }
    }
}