using EcoGuardian_Backend.IAM.Domain.Model.ValueObjects;

namespace EcoGuardian_Backend.IAM.Domain.Model.Commands;

public record SignUpCommand(string Username, string Password, string Email, EUserRoles Role);


