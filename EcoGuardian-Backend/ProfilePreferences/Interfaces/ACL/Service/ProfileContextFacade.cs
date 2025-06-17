using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Commands;
using EcoGuardian_Backend.ProfilePreferences.Domain.Services;

namespace EcoGuardian_Backend.ProfilePreferences.Interfaces.ACL.Service;

public class ProfileContextFacade(IProfileCommandService profileCommandService) : IProfileContextFacade
{
    public void CreateProfile(int userId, int subscriptionId, string name, string username, string email, string address, string avatarUrl)
    {
        var command = new CreateProfileCommand(email, name, username, address, avatarUrl, userId, subscriptionId);
        profileCommandService.Handle(command).Wait();
    }

    public void UpdateProfile(int profileId, int userId, int subscriptionId, string name, string address, string avatarUrl)
    {
        var command = new UpdateProfileCommand(profileId, name, address, avatarUrl);
        profileCommandService.Handle(command).Wait();
    }
}