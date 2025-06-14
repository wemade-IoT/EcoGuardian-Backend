using EcoGuardian_Backend.IAM.Domain.Model.Commands;
using EcoGuardian_Backend.IAM.Domain.Services;

namespace EcoGuardian_Backend.IAM.Application.Internal.Events;

public static class SeedRolesEvent
{
    public static void On(this IServiceProvider serviceProvider, SeedUserRolesCommand command)
    {
        Console.WriteLine("Seed Roles Event Triggered");
        using var scope = serviceProvider.CreateScope();
        var roleCommandService = scope.ServiceProvider.GetRequiredService<IRoleCommandService>();
        roleCommandService.Handle(command).GetAwaiter().GetResult();
        Console.WriteLine("Seed Roles Event Completed");
        
    }
}