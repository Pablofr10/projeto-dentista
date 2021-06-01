using Dentista.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dentista.Infrastructure.Commom
{
    public sealed class DentistaDbContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<ConsultaEspecialidade> ConsultaEspecialidades { get; set; }
        public DbSet<EspecialidadeProfissional> EspecialidadesProfissionaiss { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DentistaDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DentistaDbContext(DbContextOptions<DentistaDbContext> options): base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}