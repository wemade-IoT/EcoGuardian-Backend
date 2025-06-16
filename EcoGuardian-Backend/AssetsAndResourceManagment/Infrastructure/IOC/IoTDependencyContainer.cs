using EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.CommandServices;
using EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.QueryServices;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Repositories;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;
using EcoGuardian_Backend.OperationAndMonitoring.Infrastructure.Persistence.EFC;

namespace EcoGuardian_Backend.OperationAndMonitoring.Infrastructure.IOC;

public static class IoTDependencyContainer
{
    public static IServiceCollection AddIoTDependencies(this IServiceCollection services)
    {
        services.AddScoped<IIoTDeviceRepository, IoTDeviceRepository>();
        services.AddScoped<IIoTDataRepository, IoTDataRepository>();

        services.AddScoped<IIoTDeviceCommandService, IoTDeviceCommandService>();
        services.AddScoped<IIoTDeviceQueryService, IoTDeviceQueryService>();
        services.AddScoped<IIoTDataService, IoTDataService>();
        
        return services;
    }
}
