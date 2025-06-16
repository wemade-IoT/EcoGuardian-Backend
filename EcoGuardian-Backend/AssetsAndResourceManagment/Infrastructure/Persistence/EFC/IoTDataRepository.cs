using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Entities;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.OperationAndMonitoring.Infrastructure.Persistence.EFC;

public class IoTDataRepository : BaseRepository<IoTData>, IIoTDataRepository
{
    public IoTDataRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<IoTData>> GetByDeviceIdAsync(string deviceId)
    {
        return await context.Set<IoTData>()
            .Where(d => d.DeviceId == deviceId)
            .OrderByDescending(d => d.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<IoTData>> GetByDeviceIdAndTimeRangeAsync(string deviceId, DateTime startDate, DateTime endDate)
    {
        return await context.Set<IoTData>()
            .Where(d => d.DeviceId == deviceId && d.Timestamp >= startDate && d.Timestamp <= endDate)
            .OrderByDescending(d => d.Timestamp)
            .ToListAsync();
    }

    public async Task<IEnumerable<IoTData>> GetByDeviceIdAndDataTypeAsync(string deviceId, string dataType)
    {
        return await context.Set<IoTData>()
            .Where(d => d.DeviceId == deviceId && d.DataType == dataType)
            .OrderByDescending(d => d.Timestamp)
            .ToListAsync();
    }
}
