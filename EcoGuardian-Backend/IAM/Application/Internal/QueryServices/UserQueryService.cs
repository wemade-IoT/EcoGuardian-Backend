using EcoGuardian_Backend.IAM.Domain.Model.Aggregates;
using EcoGuardian_Backend.IAM.Domain.Model.Queries;
using EcoGuardian_Backend.IAM.Domain.Respositories;
using EcoGuardian_Backend.IAM.Domain.Services;

namespace EcoGuardian_Backend.IAM.Application.Internal.QueryServices;

public class UserQueryService (IUserRepository userRepository) : IUserQueryService
{
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.GetByIdAsync(query.Id);
    }
    
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.GetAllAsync();
    }
    
    public async Task<User?> Handle(GetUserByEmailQuery query)
    {
        return await userRepository.FindByEmailAsync(query.Email);
    }

    public async Task<string?> Handle(GetUsernameByIdQuery query)
    {
        return await userRepository.GetUsernameByIdAsync(query.UserId);
    }

    public bool Handle(UserExistsQuery query)
    {
        return userRepository.ExistsById(query.UserId);
    }
}