using EcoGuardian_Backend.Resources.Domain.Model.Aggregates;
using EcoGuardian_Backend.Resources.Domain.Model.Commands;
using EcoGuardian_Backend.Resources.Domain.Repositories;
using EcoGuardian_Backend.Resources.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.Resources.Application.Internal.CommandServices;

public class DeviceCommandService : IDeviceCommandService
{
    private readonly IDeviceRepository _deviceRepository;
    private readonly IBaseRepository<Device> _baseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeviceCommandService(IDeviceRepository deviceRepository, IBaseRepository<Device> baseRepository, IUnitOfWork unitOfWork)
    {
        _deviceRepository = deviceRepository;
        _baseRepository = baseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateDeviceCommand command)
    {
        var device = new Device
        {
            Type = command.Type,
            ConsumerId = command.ConsumerId
        };

        await _baseRepository.AddAsync(device);
        await _unitOfWork.CompleteAsync();
    }
}
