using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Services;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Application.Internal.Events;

public static class SeedSubscriptionTypesEvent
{
    public static void On(this IServiceProvider provider, SeedSubscriptionTypesCommand command)
    {
        // Sembrar tipos de suscripción
        using var scope = provider.CreateScope();
        var typeCommandService = scope.ServiceProvider.GetRequiredService<ISubscriptionTypeCommandService>();
        typeCommandService.Handle(command).GetAwaiter().GetResult();
        Console.WriteLine("Subscription Types Seeded Successfully");
    }
}