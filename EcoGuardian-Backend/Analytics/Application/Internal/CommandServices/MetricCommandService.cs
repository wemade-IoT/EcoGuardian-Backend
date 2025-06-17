using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Analytics.Domain.Model.Commands;
using EcoGuardian_Backend.Analytics.Domain.Repositories;
using EcoGuardian_Backend.Analytics.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.Analytics.Application.Internal.CommandServices;

public class MetricCommandService(IMetricRepository metricRepository, IUnitOfWork unitOfWork) : IMetricCommandService
{
    public async Task Handle(CreateMetricCommand command)
    {
        var metric = new Metric(command.MetricValue, command.MetricTypesId, command.DeviceId);
        await metricRepository.AddAsync(metric);
        await unitOfWork.CompleteAsync();
    }
}

