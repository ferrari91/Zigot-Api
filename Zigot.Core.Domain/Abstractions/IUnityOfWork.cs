using Microsoft.EntityFrameworkCore.Storage;
using Zigot.Core.Domain._Shared;

namespace Zigot.Core.Domain.Abstractions
{
    public interface IUnityOfWork
    {
        Task<int> SaveChangesAsync();
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity<long>;
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task RollbackAsync();
    }
}
