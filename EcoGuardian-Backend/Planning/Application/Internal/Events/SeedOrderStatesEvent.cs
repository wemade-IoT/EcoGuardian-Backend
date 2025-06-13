using EcoGuardian_Backend.Planning.Domain.Model.Commands;
using EcoGuardian_Backend.Planning.Domain.Services;

namespace EcoGuardian_Backend.Planning.Application.Internal.Events;

public static class SeedOrderStatesEvent
{
    public static void On(this IServiceProvider provider, SeedOrderStatesCommand command)
    {
        Console.WriteLine("Application Ready Event Handler Triggered");
        using var scope = provider.CreateScope();
        var orderStateCommandService = scope.ServiceProvider.GetRequiredService<IOrderStateCommandService>();
        orderStateCommandService.Handle(command).GetAwaiter().GetResult();
        Console.WriteLine("Order States Seeded Successfully");
    }
}