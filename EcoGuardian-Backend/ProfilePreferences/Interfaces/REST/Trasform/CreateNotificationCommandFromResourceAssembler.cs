using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Commands;
using EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Trasform;

public class CreateNotificationCommandFromResourceAssembler
{
    public static CreateNotificationCommand ToCommandFromResource(CreateNotificationResource resource)
    {
        return new CreateNotificationCommand(
            resource.Title,
            resource.Subject,
            resource.ProfileId
        );
    }
}