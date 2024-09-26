using Microsoft.EntityFrameworkCore.Storage;
using Zigot.Core.Domain._Shared;
using Zigot.Core.Domain.Abstractions.Repository;
using Zigot.Core.Domain.Abstractions.Works;
using Zigot.Infrastructure.Identity.Context;

namespace Zigot.Infrastructure.Identity._Shared
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private Dictionary<Type, object> _repositories;
        private IDbContextTransaction? _currentTransaction;

        public UnityOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<Type, object>();
        }

        public async Task<int> SaveChangesAsync()
        {
            var result = await _dbContext.SaveChangesAsync();
            await _dbContext.Database.CommitTransactionAsync();
            return result;
        }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity<long>
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
                return _repositories[typeof(TEntity)] as IBaseRepository<TEntity> ?? throw new ArgumentException("Repository not found.");

            var repository = new BaseRepository<TEntity>(_dbContext);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null)
                return null;

            _currentTransaction = await _dbContext.Database.BeginTransactionAsync();
            return _currentTransaction;
        }

        public async Task RollbackAsync()
        {
            try
            {
                if (_currentTransaction != null)
                    await _currentTransaction.RollbackAsync();
            }
            finally
            {
                if (_currentTransaction is not null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void Dispose()
            => _dbContext.Dispose();
    }
}
