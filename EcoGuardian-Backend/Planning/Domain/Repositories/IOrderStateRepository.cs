using EcoGuardian_Backend.Planning.Domain.Model.Entities;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.Planning.Domain.Repositories;

public interface IOrderStateRepository : IBaseRepository<OrderState>
{
    Task<bool> IsOrderStateTypeExistsAsync(string? type);
}