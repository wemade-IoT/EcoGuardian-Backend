using EcoGuardian_Backend.Planning.Domain.Model.Aggregates;

namespace EcoGuardian_Backend.Planning.Domain.Services;

public interface IOrderQueryService
{
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
}