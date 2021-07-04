using System.Text;
using Dentista.Infrastructure.Commom;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Dentista.API.Dependencies
{
    public class IdentityDependecy
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependece(serviceProvider);
        }

        private static void RepositoryDependece(IServiceCollection serviceProvider)
        {
            serviceProvider.AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 10;
                })
                .AddEntityFrameworkStores<DentistaDbContext>();
        }
    }
}