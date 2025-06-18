using System.Threading.Tasks;
using EcoGuardian_Backend.Resources.Domain.Model.Aggregates;

namespace EcoGuardian_Backend.Resources.Domain.Repositories;

public interface IDeviceRepository
{
    Task<Device?> FindByDeviceIdAsync(string deviceId);
    Task<bool> ValidateApiKeyAsync(string deviceId, string apiKey);
}

