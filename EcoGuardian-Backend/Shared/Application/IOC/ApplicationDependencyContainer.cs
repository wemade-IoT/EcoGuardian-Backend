using EcoGuardian_Backend.Planning.Application.Internal.CommandServices;
using EcoGuardian_Backend.Planning.Application.Internal.QueryServices;
using EcoGuardian_Backend.Planning.Domain.Services;

namespace EcoGuardian_Backend.Shared.Application.IOC;

public static class ApplicationDependencyContainer 
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        // Register application services here
        // Example: services.AddScoped<IExampleService, ExampleService>();

        // Register command handlers
        services.AddScoped<IOrderCommandService, OrderCommandService>();
        services.AddScoped<IOrderStateCommandService, OrderStateCommandService>();
        // Register query handlers
        services.AddScoped<IOrderQueryService, OrderQueryService>();

        // Register other application services as needed

        return services;
    }
}