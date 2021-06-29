using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repository;
using Repository.Repository.Implementation;
using Repository.UnitOfWork;

namespace Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEstateRepository, EstateRepository>();
            services.AddScoped<INormRepository, NormRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonRequestRepository, PersonRequestRepository>();
            services.AddScoped<IQueueRepository, QueueRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork.Implementation.UnitOfWork>();

            var connection = configuration.GetConnectionString("DbConnection");

            services.AddDbContext<Context>(options =>
                options.UseNpgsql(connection, builder => builder.MigrationsAssembly("WebApplication")));

            return services;
        }
    }
}