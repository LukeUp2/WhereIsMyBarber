using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhereIsMyBarber.Domain.Repositories;
using WhereIsMyBarber.Domain.Security.Cryptography;
using WhereIsMyBarber.Infra.DataAccess;
using WhereIsMyBarber.Infra.DataAccess.Repositories;
using WhereIsMyBarber.Infra.Extensions;
using WhereIsMyBarber.Infra.Security.Cryptography;

namespace WhereIsMyBarber.Infra
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);
            AddUnitOfWork(services);
            AddDbContext(services, configuration);
            AddPasswordEncrypter(services);
            AddFluentMigrator(services, configuration);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void AddUnitOfWork(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void AddPasswordEncrypter(IServiceCollection services)
        {
            services.AddScoped<IPasswordEncrypter, Sha512Encrypter>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WhereIsMyBarberDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
        }

        private static void AddFluentMigrator(IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentMigratorCore().ConfigureRunner(opt =>
            {
                opt
                    .AddSqlServer()
                    .WithGlobalConnectionString(configuration.ConnectionString())
                    .ScanIn(Assembly.Load("WhereIsMyBarber.Infra"))
                    .For.All();
            });
        }
    }
}