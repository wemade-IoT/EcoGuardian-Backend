namespace EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Resources;

public record CreateProfileResource(string Name,string Username, string Email,string Address, IFormFile AvatarUrl, int UserId, int SubscriptionId);