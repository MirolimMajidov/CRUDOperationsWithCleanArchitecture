using Domain.Entities;

namespace Application.Services;

public interface IBaseService<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync(int? from = null, int? size = null);
    Task<TEntity> GetByIdAsync(Guid id);
    Task<TEntity> CreateAsync(TEntity item);
    Task<TEntity> UpdateAsync(Guid id, TEntity item);
    Task<bool> DeleteAsync(Guid id);
}
