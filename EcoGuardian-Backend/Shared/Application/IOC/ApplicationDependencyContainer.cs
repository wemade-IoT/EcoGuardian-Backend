using EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.CommandServices;
using EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.QueryServices;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;
using EcoGuardian_Backend.SubscriptionsAndPayment.Application.Internal.CommandServices;
using EcoGuardian_Backend.SubscriptionsAndPayment.Application.Internal.QueryServices;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Repositories;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Services;
using EcoGuardian_Backend.SubscriptionsAndPayment.Infrastructure.Persistence.EFC.Repositories;

namespace EcoGuardian_Backend.Shared.Application.IOC;

public static class ApplicationDependencyContainer 
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        // Register application services here
        // Example: services.AddScoped<IExampleService, ExampleService>();

        // Register command handlers
        services.AddScoped<IPlantCommandService, PlantCommandService>();
        services.AddScoped<IPlantQueryService, PlantQueryService>();
        services.AddScoped<IWellnessStateCommandService, WellnessCommandService>();
        services.AddScoped<ISubscriptionCommandService, SubscriptionCommandService>();
        services.AddScoped<ISubscriptionQueryService, SubscriptionQueryService>();
        services.AddScoped<IPaymentCommandService, PaymentCommandService>();
        services.AddScoped<IPaymentQueryService, PaymentQueryService>();
        services.AddScoped<ISubscriptionTypeCommandService, SubscriptionTypeCommandService>();
        services.AddScoped<ISubscriptionStateCommandService, SubscriptionStateCommandService>();

        // Register other application services as needed
        /*services.AddScoped<IExternalCustomerService, ExternalCustomerService>();*/
        return services;
    }
}