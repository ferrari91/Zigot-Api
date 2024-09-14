using System.Linq.Expressions;

namespace Zigot.Core.Domain.Abstractions
{
    public interface IBaseRepository<TEntity>
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, IEnumerable<string> fields = default, CancellationToken cancellationToken = default);
        Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<IList<TEntity>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<IList<TEntity>> GetAllAsync(IEnumerable<string> fields, CancellationToken cancellationToken);
    }
}
