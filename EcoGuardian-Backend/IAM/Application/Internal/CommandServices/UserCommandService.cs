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
        
        if (user == null || !hashingService.VerifyPassword(command.Password, user.Password) ||
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

        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(command);
        user.UpdatePassword(hashedPassword);
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

    public async Task Handle(UpdateRoleCommand command)
    {
        var user = await userRepository.GetByIdAsync(command.UserId);
        if (user == null)
            throw new Exception("User not found");

        user.UpdateRoleId(command.RoleId);
        try
        {
            userRepository.Update(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while updating user role: {e.Message}");
        }
    }
}
