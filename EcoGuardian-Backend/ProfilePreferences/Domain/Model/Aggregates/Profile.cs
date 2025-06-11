using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Commands;

namespace EcoGuardian_Backend.ProfilePreferences.Domain.Model.Aggregates;

public class Profile
{
    public int Id { get; }
    
    public string Name { get; private set; }
    
    public string UserName { get; private set; }
    
    public string Email { get; private set; }
    
    public string Address { get; private set; }
    
    public string AvatarUrl { get; private set; }
    
    public int UserId { get; private set; }
    
    public int SubscriptionId { get; private set; }

    public Profile()
    {
        Name = string.Empty;
        UserName = string.Empty;
        Email = string.Empty;
        Address = string.Empty;
        UserId = 0;
        SubscriptionId = 0;
        AvatarUrl = string.Empty;
    }

    public Profile(CreateProfileCommand command)
    {
        this.Name = command.Name;
        this.UserName = command.UserName;
        this.Email = command.Email;
        this.Address = command.Address;
        this.UserId = command.UserId;
        this.SubscriptionId = command.SubscriptionId;
        this.AvatarUrl = command.AvatarUrl;
    }

