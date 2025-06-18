namespace EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Resources;

public record CreateNotificationResource(string Title, string Subject, int ProfileId);