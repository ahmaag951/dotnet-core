using AutoMapper;
using Lookups.Data;
using Lookups.DataAccess;
using Lookups.DataAccess.Repositories;
using Lookups.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Linq;
using System.Reflection;

namespace Lookups.Service.Extensions
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection ServicesRegisterConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.DatabaseConfig(configuration);
            services.AddAutoMapper();
            services.ServicesConfig();
            services.DataAccessConfig();
            return services;
        }
        private static void DatabaseConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TAMS");
            services.AddDbContext<LookupsContext>
                (options => options.UseSqlServer(connectionString));
            services.AddScoped<DbContext, LookupsContext>();
        }
        private static void ServicesConfig(this IServiceCollection services)
        {
            services.AddScoped<IUnitofWork, UnitofWork>();
            var assemblyToScan = Assembly.GetAssembly(typeof(CountryService));
            services.RegisterAssemblyPublicNonGenericClasses(assemblyToScan)
              .Where(c => c.Name.EndsWith("Service"))
              .AsPublicImplementedInterfaces().BuildServiceProvider();
        }
        private static void DataAccessConfig(this IServiceCollection services)
        {
            var assemblyToScan = Assembly.GetAssembly(typeof(CountryRepository));
            services.RegisterAssemblyPublicNonGenericClasses(assemblyToScan)
              .Where(c => c.Name.EndsWith("Repository"))
              .AsPublicImplementedInterfaces().BuildServiceProvider();
        }
    }
}
