using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Aggregates;
using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Commands;
using EcoGuardian_Backend.ProfilePreferences.Domain.Repositories;
using EcoGuardian_Backend.ProfilePreferences.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.ProfilePreferences.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IProfileCommandService
{
    public async Task Handle(CreateProfileCommand command)
    {
        if(profileRepository.IsEmailExists(command.Email))
        {
            throw new BadHttpRequestException($"Profile with email {command.Email} already exists.");
        }

        if (profileRepository.IsUserNameExists(command.UserName))
        {
            throw new BadHttpRequestException($"Profile with username {command.UserName} already exists.");
        }
        var profile = new Profile(command);
        await profileRepository.AddAsync(profile);
        await unitOfWork.CompleteAsync();
    }

    public async Task Handle(UpdateProfileCommand command)
    {
        var profile = await profileRepository.GetByIdAsync(command.Id);
        if (profile == null)
        {
            throw new BadHttpRequestException($"Profile with ID {command.Id} not found.");
        }
        profile.Update(command);
        profileRepository.Update(profile);
        await unitOfWork.CompleteAsync();
    }
}