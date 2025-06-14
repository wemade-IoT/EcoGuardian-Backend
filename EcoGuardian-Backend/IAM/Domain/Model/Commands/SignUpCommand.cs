
namespace EcoGuardian_Backend.IAM.Domain.Model.Commands;

public record SignUpCommand(string Password, string Email, int RoleId);


