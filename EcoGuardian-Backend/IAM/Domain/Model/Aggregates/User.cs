using EcoGuardian_Backend.IAM.Domain.Model.Commands;

namespace EcoGuardian_Backend.IAM.Domain.Model.Aggregates;

public class User
{

    public int Id { get; }

    public string Email { get; private set; }
    
    public string Password { get; private set; }

    public int RoleId { get; private set; }

    public User()
    {
        Email = string.Empty;
        Password = string.Empty;
        RoleId = 0;
    }


    public User(SignUpCommand command)
    {
        Email = command.Email;
        Password = command.Password;
        RoleId = command.RoleId;

    }
    

    public void UpdateRoleId(int roleId)
    {
        RoleId = roleId;
    }

    public void UpdatePassword(string password)
    {
        Password = password;
    }
    
    
}