using EcoGuardian_Backend.Planning.Domain.Model.Commands;
using EcoGuardian_Backend.Planning.Domain.Services;

namespace EcoGuardian_Backend.Planning.Application.Internal.EventHandlers;

public static class ApplicationReadyEventHandler
{
    public static void On(this IServiceProvider provider)
    {
        Console.WriteLine("Application Ready Event Handler Triggered");
        var command = new SeedOrderStatesCommand();
        using var scope = provider.CreateScope();
        var orderStateCommandService = scope.ServiceProvider.GetRequiredService<IOrderStateCommandService>();
        orderStateCommandService.Handle(command).GetAwaiter().GetResult();
        Console.WriteLine("Order States Seeded Successfully");
    }
}