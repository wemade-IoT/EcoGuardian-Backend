using System.Collections.Generic;
using System.Threading.Tasks;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Repositories;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;

namespace EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.QueryServices;
public class IoTDeviceQueryService : IIoTDeviceQueryService
{
    private readonly IIoTDeviceRepository _iotDeviceRepository;

    public IoTDeviceQueryService(IIoTDeviceRepository iotDeviceRepository)
    {
        _iotDeviceRepository = iotDeviceRepository;
    }

    public async Task<IEnumerable<IoTDevice>> GetAllDevicesAsync()
    {
        return await _iotDeviceRepository.GetAllAsync();
    }

    public async Task<IoTDevice?> GetDeviceByIdAsync(int id)
    {
        return await _iotDeviceRepository.GetByIdAsync(id);
    }

    public async Task<IoTDevice?> GetDeviceByDeviceIdAsync(string deviceId)
    {
        return await _iotDeviceRepository.GetByDeviceIdAsync(deviceId);
    }

    public async Task<IEnumerable<IoTDevice>> GetDevicesByUserIdAsync(int userId)
    {
        return await _iotDeviceRepository.GetByUserIdAsync(userId);
    }

    public async Task<IEnumerable<IoTDevice>> GetDevicesByPlantIdAsync(int plantId)
    {
        return await _iotDeviceRepository.GetByPlantIdAsync(plantId);
    }
}
