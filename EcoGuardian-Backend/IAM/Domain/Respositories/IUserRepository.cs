using EcoGuardian_Backend.IAM.Domain.Model.Aggregates;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.IAM.Domain.Respositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByEmailAsync (string email);
    bool ExistsByUsername(string username);
    
    Task<string?> GetUsernameByIdAsync(int userId);
    
    bool ExistsById(int userId);
}