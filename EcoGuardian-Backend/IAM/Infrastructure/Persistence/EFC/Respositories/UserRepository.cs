using EcoGuardian_Backend.IAM.Domain.Model.Aggregates;
using EcoGuardian_Backend.IAM.Domain.Respositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.IAM.Infrastructure.Persistence.EFC.Respositories;

/**
 * <summary>
 *     The user repository
 * </summary>
 * <remarks>
 *     This repository is used to manage users
 * </remarks>
 */
public class UserRepository (AppDbContext context) : BaseRepository<User>(context), IUserRepository 
{
    /**
     * <summary>
     *     Find a user by username
     * </summary>
     * <param name="email">The username to search</param>
     * <returns>The user</returns>
     */
    public async Task<User?> FindByEmailAsync(string email)
    {
        return await context.Set<User>().FirstOrDefaultAsync(user => user.Email == email);
    }
    
    /**
     * <summary>
     *     Check if a user exists by username
     * </summary>
     * <param name="username">The username to search</param>
     * <returns>True if the user exists, false otherwise</returns>
     */
    public bool ExistsByUsername(string username)
    {
        return context.Set<User>().Any(user => user.Username.Equals(username));
    }

    public async Task<string?> GetUsernameByIdAsync(int userId)
    {
        return await context.Set<User>().Where(user => user.Id == userId).Select(user => user.Username).FirstOrDefaultAsync();
    }

    public bool ExistsById(int userId)
    {
        return context.Set<User>().Any(user => user.Id == userId);
    }
}