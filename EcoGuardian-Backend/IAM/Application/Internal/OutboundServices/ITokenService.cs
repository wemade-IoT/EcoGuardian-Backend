using EcoGuardian_Backend.IAM.Domain.Model.Aggregates;

namespace EcoGuardian_Backend.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}