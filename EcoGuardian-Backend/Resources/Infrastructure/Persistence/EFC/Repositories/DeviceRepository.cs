using EcoGuardian_Backend.Resources.Domain.Model.Entities;
using EcoGuardian_Backend.Resources.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.Resources.Infrastructure.Persistence.EFC.Repositories;

public class DeviceRepository(AppDbContext context) : IDeviceRepository
{
    public async Task<Device?> FindByDeviceIdAsync(string deviceId)
    {
        return await context.Set<Device>().FirstOrDefaultAsync(d => d.DeviceId == deviceId);
    }

    public async Task<bool> ValidateApiKeyAsync(string deviceId, string apiKey)
    {
        var device = await FindByDeviceIdAsync(deviceId);
        return device != null && device.ApiKey == apiKey;
    }
}

