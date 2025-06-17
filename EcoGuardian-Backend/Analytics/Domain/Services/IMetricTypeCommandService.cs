using EcoGuardian_Backend.Analytics.Domain.Model.Commands;

namespace EcoGuardian_Backend.Analytics.Domain.Services;

public interface IMetricTypeCommandService
{
    Task Handle(SeedMetricTypesCommand command);
}