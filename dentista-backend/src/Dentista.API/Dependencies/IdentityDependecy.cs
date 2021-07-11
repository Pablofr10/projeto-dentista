using System.Text;
using Dentista.Infrastructure.Commom;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Dentista.API.Dependencies
{
    public class IdentityDependecy
    {
        public static void Register(IServiceCollection serviceProvider, string token)
        {
            RepositoryDependece(serviceProvider, token);
        }

        private static void RepositoryDependece(IServiceCollection serviceProvider, string token)
        {
            var builder = serviceProvider.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<DentistaDbContext>();
            builder.AddRoleValidator<RoleValidator<IdentityRole>>();
            builder.AddRoleManager<RoleManager<IdentityRole>>();
            builder.AddSignInManager<SignInManager<IdentityUser>>();

            serviceProvider.AddAuthentication(optionsAutenticate =>
                {
                    optionsAutenticate.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    optionsAutenticate.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token)),
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                });
        }
    }
}