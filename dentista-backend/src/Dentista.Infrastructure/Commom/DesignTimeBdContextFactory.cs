using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Dentista.Infrastructure.Commom
{
    public class DesignTimeBdContextFactory : IDesignTimeDbContextFactory<DentistaDbContext>
    {
        public DentistaDbContext CreateDbContext(string[] args)
        {
            //var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") || "Development";
            var environmentName = "Development";

            var fileName = Directory.GetCurrentDirectory() + $"/../Dentista.API/appsettings.{environmentName}.json";

            var configuration = new ConfigurationBuilder().AddJsonFile(fileName).Build();
            var connectionString = configuration.GetConnectionString("App");

            var builder = new DbContextOptionsBuilder<DentistaDbContext>();
            builder.UseNpgsql(connectionString);

            return new DentistaDbContext(builder.Options);
        }
    }
}