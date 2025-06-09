namespace EcoGuardian_Backend.IAM.Domain.Model.Commands;

public record UpdateRoleCommand(int RoleId, int UserId);