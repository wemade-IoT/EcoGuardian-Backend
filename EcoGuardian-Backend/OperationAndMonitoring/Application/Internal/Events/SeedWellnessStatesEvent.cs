
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;

namespace EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.Events;

public static class SeedWellnessStatesEvent
{
    public static void On(this IServiceProvider provider, SeedWellnessStatesCommand command)
    {
        Console.WriteLine("Application Ready Event Triggered");
        using var scope = provider.CreateScope();
        var wellnessCommandService = scope.ServiceProvider.GetRequiredService<IWellnessStateCommandService>();
        wellnessCommandService.Handle(command).GetAwaiter().GetResult();
        Console.WriteLine("Wellness States Seeded Successfully");
    }
}