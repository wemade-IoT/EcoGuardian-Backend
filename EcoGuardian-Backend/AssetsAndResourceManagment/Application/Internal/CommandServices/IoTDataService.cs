using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Entities;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Repositories;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.CommandServices;

public class IoTDataService : IIoTDataService
{
    private readonly IIoTDataRepository _iotDataRepository;
    private readonly IIoTDeviceRepository _iotDeviceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public IoTDataService(IIoTDataRepository iotDataRepository, IIoTDeviceRepository iotDeviceRepository, IUnitOfWork unitOfWork)
    {
        _iotDataRepository = iotDataRepository;
        _iotDeviceRepository = iotDeviceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IoTData> RegisterDataAsync(string deviceId, string dataType, string value, string unit, DateTime timestamp)
    {
        // Verificar si el dispositivo existe
        var device = await _iotDeviceRepository.GetByDeviceIdAsync(deviceId);
        if (device == null)
            throw new InvalidOperationException($"No existe un dispositivo con el ID {deviceId}");
        
        // Verificar si el dispositivo está activo
        if (!device.IsActive)
            throw new InvalidOperationException($"El dispositivo con ID {deviceId} está inactivo");

        // Crear nuevo registro de datos
        var data = new IoTData(deviceId, dataType, value, unit, timestamp);
        
        // Guardar en el repositorio
        await _iotDataRepository.AddAsync(data);
        await _unitOfWork.CompleteAsync();
        
        return data;
    }

    public async Task<IEnumerable<IoTData>> GetDataByDeviceIdAsync(string deviceId)
    {
        return await _iotDataRepository.GetByDeviceIdAsync(deviceId);
    }

    public async Task<IEnumerable<IoTData>> GetDataByTimeRangeAsync(string deviceId, DateTime startDate, DateTime endDate)
    {
        return await _iotDataRepository.GetByDeviceIdAndTimeRangeAsync(deviceId, startDate, endDate);
    }

    public async Task<IEnumerable<IoTData>> GetDataByTypeAsync(string deviceId, string dataType)
    {
        return await _iotDataRepository.GetByDeviceIdAndDataTypeAsync(deviceId, dataType);
    }

    public async Task<int> PurgeOldDataAsync(string deviceId, DateTime olderThan)
    {
        var oldData = await _iotDataRepository.GetByDeviceIdAndTimeRangeAsync(deviceId, DateTime.MinValue, olderThan);
        int count = 0;
        
        foreach (var data in oldData)
        {
            _iotDataRepository.DeleteAsync(data);
            count++;
        }
        
        await _unitOfWork.CompleteAsync();
        return count;
    }
}