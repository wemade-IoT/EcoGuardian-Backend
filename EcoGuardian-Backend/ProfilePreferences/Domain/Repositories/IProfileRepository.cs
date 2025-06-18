using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Aggregates;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.ProfilePreferences.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<Profile?> GetProfileByEmailAsync(string email);
    bool IsEmailExists(string email);
    
    bool IsUserNameExists(string userName);
}