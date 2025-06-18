namespace EcoGuardian_Backend.CRM.Application.Internal.OutboundServices;

public interface IExternalUserServiceCRM
{
        Task<bool> CheckUserExists(int userId);
        Task<bool> CheckPlantExists(int plantId);
}