using Microsoft.Extensions.DependencyInjection;

namespace Dentista.API.Dependencies
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependence(serviceProvider);
        }
        private static void RepositoryDependence(IServiceCollection serviceProvider)
        {
            
        }
    }
}