using EcoGuardian_Backend.IAM.Application.Internal.Events;
using EcoGuardian_Backend.IAM.Domain.Model.Commands;
using EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.EventHandlers;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;

namespace EcoGuardian_Backend.Shared.Application.Internal.EventHandler;

public static class ApplicationReadyEventHandler
{
    public static void OnStart(this IServiceProvider provider)
    {
        Console.WriteLine("Application Ready Event Triggered");
        var seedRolesCommand = new SeedUserRolesCommand();
        var seedWellnessCommand = new SeedWellnessStatesCommand();
        provider.On(seedWellnessCommand);
        provider.On(seedRolesCommand);
        Console.WriteLine("Application Ready Event Completed");
        
    }
}