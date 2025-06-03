using EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.CommandServices;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;

namespace EcoGuardian_Backend.Shared.Application.IOC;

public static class ApplicationDependencyContainer 
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        // Register application services here
        // Example: services.AddScoped<IExampleService, ExampleService>();

        // Register command handlers
        services.AddScoped<IPlantCommandService, PlantCommandService>();
        services.AddScoped<IWellnessStateCommandService, WellnessCommandService>();
        

        // Register other application services as needed

        return services;
    }
}