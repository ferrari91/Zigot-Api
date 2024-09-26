using Microsoft.EntityFrameworkCore.Storage;
using Zigot.Core.Domain._Shared;
using Zigot.Core.Domain.Abstractions.Repository;

namespace Zigot.Core.Domain.Abstractions.Works
{
    public interface IUnityOfWork
    {
        Task<int> SaveChangesAsync();
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity<long>;
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task RollbackAsync();
    }
}
