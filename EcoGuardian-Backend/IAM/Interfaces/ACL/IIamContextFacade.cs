using EcoGuardian_Backend.IAM.Domain.Model.ValueObjects;

namespace EcoGuardian_Backend.IAM.Interfaces.ACL;

public interface IIamContextFacade
{
    Task<int> CreateUser(string username, string password, string email, EUserRoles role);
    Task<int> FetchUserIdByUsername(string username);
    Task<string> FetchUsernameByUserId(int userId);
    
   bool UsersExists(int userId);
}