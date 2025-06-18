using EcoGuardian_Backend.Analytics.Domain.Model.Commands;

namespace EcoGuardian_Backend.Analytics.Domain.Services;

public interface IMetricCommandService
{
    Task Handle(CreateMetricCommand command);
}