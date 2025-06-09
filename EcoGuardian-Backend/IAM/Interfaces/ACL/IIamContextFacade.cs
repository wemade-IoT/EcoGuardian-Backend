namespace EcoGuardian_Backend.IAM.Interfaces.ACL;

public interface IIamContextFacade
{
    
   Task<bool> UsersExists(int userId);
   Task UpdateRoleId(int userId, int roleId);
}