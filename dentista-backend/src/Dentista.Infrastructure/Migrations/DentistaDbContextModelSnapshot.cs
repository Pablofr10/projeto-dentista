﻿// <auto-generated />
using System;
using Dentista.Infrastructure.Commom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dentista.Infrastructure.Migrations
{
    [DbContext(typeof(DentistaDbContext))]
    partial class DentistaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "6.0.0-preview.4.21253.1")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Dentista.Core.Entities.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("EspecialidadeId")
                        .HasColumnType("integer")
                        .HasColumnName("id_profissional");

                    b.Property<string>("NomeDentista")
                        .HasColumnType("text");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("integer");

                    b.Property<int>("PagamentoId")
                        .HasColumnType("integer")
                        .HasColumnName("id_pagamento");

                    b.Property<int>("ProcedimentoId")
                        .HasColumnType("integer")
                        .HasColumnName("id_procedimento");

                    b.Property<int>("Status")
                        .HasMaxLength(1)
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadeId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("PagamentoId");

                    b.HasIndex("ProcedimentoId");

                    b.ToTable("tb_consulta");
                });

            modelBuilder.Entity("Dentista.Core.Entities.Especialidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Ativa")
                        .HasColumnType("boolean")
                        .HasColumnName("ativa");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_especialidade");
                });

            modelBuilder.Entity("Dentista.Core.Entities.EspecialidadeProfissional", b =>
                {
                    b.Property<int>("ProcedimentoId")
                        .HasColumnType("integer")
                        .HasColumnName("id_procedimento");

                    b.Property<int>("ProfissionalId")
                        .HasColumnType("integer")
                        .HasColumnName("id_profissional");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("status");

                    b.HasKey("ProcedimentoId", "ProfissionalId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("tb_procedimento_profissional");
                });

            modelBuilder.Entity("Dentista.Core.Entities.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CEP")
                        .HasMaxLength(8)
                        .HasColumnType("integer")
                        .HasColumnName("CEP");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("celular");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("cidade");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("criado_em");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("endereco");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("sexo");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.ToTable("tb_paciente");
                });

            modelBuilder.Entity("Dentista.Core.Entities.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("FormaPagamento")
                        .HasMaxLength(2)
                        .HasColumnType("integer")
                        .HasColumnName("forma_pagamento");

                    b.Property<DateTime>("PagoEm")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("pago_em");

                    b.Property<decimal>("Preco")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("preco");

                    b.Property<int>("Status")
                        .HasMaxLength(2)
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("tb_pagamento");
                });

            modelBuilder.Entity("Dentista.Core.Entities.Profissional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_profissional");
                });

            modelBuilder.Entity("Dentista.Core.Entities.Consulta", b =>
                {
                    b.HasOne("Dentista.Core.Entities.Profissional", "Profissional")
                        .WithMany()
                        .HasForeignKey("EspecialidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dentista.Core.Entities.Paciente", null)
                        .WithMany("Consultas")
                        .HasForeignKey("PacienteId");

                    b.HasOne("Dentista.Core.Entities.Pagamento", "Pagamento")
                        .WithMany()
                        .HasForeignKey("PagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dentista.Core.Entities.Especialidade", "Especialidade")
                        .WithMany()
                        .HasForeignKey("ProcedimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidade");

                    b.Navigation("Pagamento");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("Dentista.Core.Entities.EspecialidadeProfissional", b =>
                {
                    b.HasOne("Dentista.Core.Entities.Especialidade", "Especialidade")
                        .WithMany()
                        .HasForeignKey("ProcedimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dentista.Core.Entities.Profissional", "Profissional")
                        .WithMany()
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especialidade");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("Dentista.Core.Entities.Paciente", b =>
                {
                    b.Navigation("Consultas");
                });
#pragma warning restore 612, 618
        }
    }
}
