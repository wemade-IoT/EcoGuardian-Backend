namespace EcoGuardian_Backend.Planning.Application.Internal.OutboundServices;

public interface IExternalUserService
{
    Task<bool> CheckUserExists(int userId);
}