using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Services;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Application.Internal.EventHandlers;

public static class ApplicationReadyEventHandler
{
    public static void On(this IServiceProvider provider)
    {
        Console.WriteLine("Application Ready Event Triggered");
        // Sembrar estados de suscripción
        var stateCommand = new SeedSubscriptionStatesCommand();
        var scope = provider.CreateScope();
        var stateCommandService = scope.ServiceProvider.GetRequiredService<ISubscriptionStateCommandService>();
        stateCommandService.Handle(stateCommand).GetAwaiter().GetResult();
        Console.WriteLine("Wellness States Seeded Successfully");

        // Sembrar tipos de suscripción
        var typeCommand = new SeedSubscriptionTypesCommand();
        var typeCommandService = scope.ServiceProvider.GetRequiredService<ISubscriptionTypeCommandService>();
        typeCommandService.Handle(typeCommand).GetAwaiter().GetResult();
        Console.WriteLine("Subscription Types Seeded Successfully");
    }
}