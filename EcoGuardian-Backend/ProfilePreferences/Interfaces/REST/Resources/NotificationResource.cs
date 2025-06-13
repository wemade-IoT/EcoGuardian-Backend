namespace EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Resources;

public record NotificationResource(int Id, string Title, string Subject, int ProfileId, DateTime CreatedAt);