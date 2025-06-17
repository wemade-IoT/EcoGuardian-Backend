using EcoGuardian_Backend.Analytics.Domain.Model.Commands;
using EcoGuardian_Backend.Analytics.Domain.Services;

namespace EcoGuardian_Backend.Analytics.Application.Internal.Events;

public static class SeedMetricTypesEvent
{
    public static void On(this IServiceProvider provider, SeedMetricTypesCommand command)
    {
        Console.WriteLine("Seeding Metric Types...");
        using var scope = provider.CreateScope();
        var metricTypeCommandService = scope.ServiceProvider.GetRequiredService<IMetricTypeCommandService>();
        metricTypeCommandService.Handle(command).GetAwaiter().GetResult();
        Console.WriteLine("Metric Types Seeded Successfully");
    }
}

