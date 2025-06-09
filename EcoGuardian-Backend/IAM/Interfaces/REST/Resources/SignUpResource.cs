
namespace EcoGuardian_Backend.IAM.Interfaces.REST.Resources;

public record SignUpResource(string Email, string Password, int RoleId);