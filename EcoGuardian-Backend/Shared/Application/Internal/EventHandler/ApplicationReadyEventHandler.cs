using EcoGuardian_Backend.IAM.Application.Internal.Events;
using EcoGuardian_Backend.IAM.Domain.Model.Commands;
using EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.Events;
using EcoGuardian_Backend.SubscriptionsAndPayment.Application.Internal.Events;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;


namespace EcoGuardian_Backend.Shared.Application.Internal.EventHandler;

public static class ApplicationReadyEventHandler
{
    public static void OnStart(this IServiceProvider provider)
    {
        Console.WriteLine("Application Ready Event Triggered");
        var seedRolesCommand = new SeedUserRolesCommand();
        var seedWellnessCommand = new SeedWellnessStatesCommand();
        var seedSubscriptionTypesCommand = new SeedSubscriptionTypesCommand();
        var seedSubscriptionStatesCommand = new SeedSubscriptionStatesCommand();
        provider.On(seedWellnessCommand);
        provider.On(seedRolesCommand);
        provider.On(seedSubscriptionStatesCommand);
        provider.On(seedSubscriptionTypesCommand);
        Console.WriteLine("Application Ready Event Completed");
        
    }
}