using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.OperationAndMonitoring.Infrastructure.Persistence.EFC;

public class IoTDeviceRepository : BaseRepository<IoTDevice>, IIoTDeviceRepository
{
    public IoTDeviceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<IoTDevice>> GetByUserIdAsync(int userId)
    {
        return await _context.Set<IoTDevice>()
            .Where(d => d.UserId == userId)
            .ToListAsync();
    }

    public async Task<IoTDevice?> GetByDeviceIdAsync(string deviceId)
    {
        return await _context.Set<IoTDevice>()
            .FirstOrDefaultAsync(d => d.DeviceId == deviceId);
    }

    public async Task<IEnumerable<IoTDevice>> GetByPlantIdAsync(int plantId)
    {
        return await _context.Set<IoTDevice>()
            .Where(d => d.PlantId == plantId)
            .ToListAsync();
    }
}
