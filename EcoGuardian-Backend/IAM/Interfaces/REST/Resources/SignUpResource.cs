using EcoGuardian_Backend.IAM.Domain.Model.ValueObjects;

namespace EcoGuardian_Backend.IAM.Interfaces.REST.Resources;

public record SignUpResource(string Username, string Password, string Email , EUserRoles Role);