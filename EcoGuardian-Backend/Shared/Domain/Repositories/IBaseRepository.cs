namespace EcoGuardian_Backend.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<bool> AddAsync(TEntity entity);
    void Update(TEntity entity);
    void DeleteAsync(TEntity entity);
}