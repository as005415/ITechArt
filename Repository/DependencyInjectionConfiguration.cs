using System.Reflection;
using Autofac;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repository;
using Repository.Repository.Implementation;
using Repository.UnitOfWork;

namespace Repository
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services,
            IConfiguration configuration)
        {
            var dataAccess = Assembly.GetExecutingAssembly();

            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t =>
                    t.Name.EndsWith("Repository") &&
                    t.Name.EndsWith("UnitOfWork"))
                .InstancePerLifetimeScope()
                .AsImplementedInterfaces();

            var connection = configuration.GetConnectionString("DbConnection");

            services.AddDbContext<Context>(options =>
                options.UseNpgsql(connection, optionsBuilder =>
                    optionsBuilder.MigrationsAssembly("WebApplication")));

            return services;
        }
    }
}