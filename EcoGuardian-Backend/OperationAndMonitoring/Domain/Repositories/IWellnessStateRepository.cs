using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Entities;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Repositories;

public interface IWellnessStateRepository : IBaseRepository<WellnessState>
{
    Task<bool> IsWellnessStateTypeExistsAsync(string? type);
}