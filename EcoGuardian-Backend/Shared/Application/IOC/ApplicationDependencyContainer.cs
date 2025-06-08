using EcoGuardian_Backend.Planning.Domain.Services;

namespace EcoGuardian_Backend.Shared.Application.IOC;

public static class ApplicationDependencyContainer 
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        // Register application services here
        // Example: services.AddScoped<IExampleService, ExampleService>();

        // Register command handlers

        // Register other application services as needed

        return services;
    }
}