﻿using Dentista.Application.Services;
using Dentista.Core.Entities;
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
            RepositoryDependence(serviceProvider);
        }
        private static void ServiceDependence(IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IPacienteService, PacienteService>();
        }
        
        private static void RepositoryDependence(IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IPacienteRepository, PacienteRepository>();
        }
    }
}