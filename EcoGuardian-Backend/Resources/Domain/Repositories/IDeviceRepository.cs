using EcoGuardian_Backend.Resources.Domain.Model.Entities;
using System.Threading.Tasks;

namespace EcoGuardian_Backend.Resources.Domain.Repositories;

public interface IDeviceRepository
{
    Task<Device?> FindByDeviceIdAsync(string deviceId);
    Task<bool> ValidateApiKeyAsync(string deviceId, string apiKey);
}

