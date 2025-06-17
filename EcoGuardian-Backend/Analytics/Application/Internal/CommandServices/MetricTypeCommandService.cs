using EcoGuardian_Backend.Analytics.Domain.Model.ValueObjects;
using EcoGuardian_Backend.Analytics.Domain.Model.Entities;
using EcoGuardian_Backend.Analytics.Domain.Model.Commands;
using EcoGuardian_Backend.Analytics.Domain.Repositories;
using EcoGuardian_Backend.Analytics.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.Analytics.Application.Internal.CommandServices;

public class MetricTypeCommandService : IMetricTypeCommandService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMetricTypeRepository _metricTypeRepository;

    public MetricTypeCommandService(IUnitOfWork unitOfWork, IMetricTypeRepository metricTypeRepository)
    {
        _unitOfWork = unitOfWork;
        _metricTypeRepository = metricTypeRepository;
    }

    public async Task Handle(SeedMetricTypesCommand command)
    {
        var metricTypes = Enum.GetValues(typeof(MetricTypes)).Cast<MetricTypes>();
        foreach (var metricType in metricTypes)
        {
            var type = metricType.ToString();
            var exists = await _metricTypeRepository.IsMetricTypeExistsAsync(type);
            if (exists)
                continue;
            var newMetricType = new MetricType(type);
            await _metricTypeRepository.AddAsync(newMetricType);
            await _unitOfWork.CompleteAsync();
        }
    }
}
