namespace EcoGuardian_Backend.ProfilePreferences.Interfaces.ACL;

public interface IProfileContextFacade
{
    void CreateProfile(int userId, int subscriptionId, string name, string username, string email, string address, string avatarUrl);
    void UpdateProfile(int profileId, int userId, int subscriptionId, string name, string address, string avatarUrl);
}