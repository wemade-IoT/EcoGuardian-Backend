using EcoGuardian_Backend.Planning.Domain.Repositories;
using EcoGuardian_Backend.Planning.Infrastructure.Persistence.EFC.Repositories;
using EcoGuardian_Backend.Shared.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.Shared.Infrastructure.IOC;

public static class InfrastructureDependencyContainer 
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, WebApplicationBuilder builder, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderStateRepository, OrderStateRepository>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        services.AddDbContext<AppDbContext>(db =>
        {
            if (builder.Environment.IsDevelopment())
            {
               db.UseMySql(configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")));
            }
            else if (builder.Environment.IsProduction())
            {
                db.UseMySql(configuration.GetConnectionString("ProductionConnection"), ServerVersion.AutoDetect(configuration.GetConnectionString("ProductionConnection")));
            }
        });
        return services;
    }
}