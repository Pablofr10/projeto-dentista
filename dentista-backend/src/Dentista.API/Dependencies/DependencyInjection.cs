using Dentista.Application.Services;
using Dentista.Core.Interfaces.Repositories;
using Dentista.Core.Interfaces.Services;
using Dentista.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Dentista.API.Dependencies
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            ServiceDependence(serviceProvider);
        }

        private static void ServiceDependence(IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IPacienteService, PacienteService>();
            serviceProvider.AddScoped<IPacienteRepository, PacienteRepository>();
            serviceProvider.AddScoped<IConsultaService, ConsultaService>();
            serviceProvider.AddScoped<IConsultaRepository, ConsultaRepository>();
            serviceProvider.AddScoped<IProfissionalService, ProfissionalService>();
            serviceProvider.AddScoped<IProfissionalRepository, ProfissionalRepository>();
            serviceProvider.AddScoped<IEspecialidadeService, EspecialidadeService>();
            serviceProvider.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
            serviceProvider.AddTransient<IAutenticacaoService, AutenticacaoService>();
            serviceProvider.AddScoped<IAdministracaoService, AdministracaoService>();
        }
    }
}