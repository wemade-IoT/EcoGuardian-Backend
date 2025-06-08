using EcoGuardian_Backend.IAM.Application.Internal.OutboundServices;
using EcoGuardian_Backend.IAM.Domain.Model.Aggregates;
using EcoGuardian_Backend.IAM.Domain.Model.Commands;
using EcoGuardian_Backend.IAM.Domain.Respositories;
using EcoGuardian_Backend.IAM.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.IAM.Application.Internal.CommandServices;

public class UserCommandService(
    IUserRepository userRepository,
    ITokenService tokenService,
    IHashingService hashingService,
    IUnitOfWork unitOfWork)
    : IUserCommandService
{
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByEmailAsync(command.Email);

        if (user == null || !hashingService.VerifyPassword(command.Password, user.PasswordHash) ||
            !command.Email.Contains('@'))
            throw new Exception("Invalid email or password");

        var token = tokenService.GenerateToken(user);

        return (user, token);
    }

    public async Task<User?> Handle(SignUpCommand command)
    {
        if (command.Password.Length < 6)
            throw new Exception("Password must be at least 6 characters long");
        if (!command.Password.Any(char.IsUpper))
            throw new Exception("Password must contain at least one uppercase letter");
        if (!command.Password.Any(char.IsLower))
            throw new Exception("Password must contain at least one lowercase letter");
        if(!command.Email.Contains('@'))
            throw new Exception("Invalid email address");

        if (userRepository.ExistsByUsername(command.Username))
            throw new Exception($"Username {command.Username} is already taken");

        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(command.Username, hashedPassword, command.Email);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync(); // Save the user first
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating user: {e.Message}");
        }


        return user;
    }

    public async Task<User?> Handle(UpdateUsernameCommand command)
    {
        var userToUpdate = await userRepository.GetByIdAsync(command.Id);
        if (userToUpdate == null)
            throw new Exception("User not found");
        var userExists = userRepository.ExistsByUsername(command.Username);
        if (userExists)
        {
            throw new Exception("This username already exists");
        }

        userToUpdate.UpdateUsername(command.Username);
        await unitOfWork.CompleteAsync();
        return userToUpdate;
    }
    
}
