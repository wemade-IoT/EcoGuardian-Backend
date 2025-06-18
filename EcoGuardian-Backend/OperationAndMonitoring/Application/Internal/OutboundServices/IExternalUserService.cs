namespace EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.OutboundServices;

public interface IExternalUserService
{
    Task<bool> CheckUserExists(int userId);
}