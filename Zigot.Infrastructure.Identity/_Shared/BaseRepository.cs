using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using Zigot.Core.Domain._Shared;
using Zigot.Core.Domain._Shared.Extensions;
using Zigot.Core.Domain.Abstractions.Repository;
using Zigot.Infrastructure.Identity.Context;


namespace Zigot.Infrastructure.Identity._Shared
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity<long>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, IEnumerable<string>? fields = default, CancellationToken cancellationToken = default)
        {
            var query = _dbSet.Where(predicate).AsQueryable();

            if (fields != null && fields.Any())
            {
                var selectedFields = GetSelectedFields(fields);

                if (selectedFields.Any())
                    query = ApplyFieldSelection(query, selectedFields);
            }

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public async Task<IList<TEntity>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var skip = (pageNumber - 1) * pageSize;

            return await _dbSet.Skip(skip).Take(pageSize).ToListAsync(cancellationToken);
        }

        public async Task<IList<TEntity>> GetAllAsync(IEnumerable<string> fields, CancellationToken cancellationToken)
        {
            var query = _dbSet.AsQueryable();

            if (fields != null && fields.Any())
            {
                var selectedFields = GetSelectedFields(fields);

                if (selectedFields.Any())
                    query = ApplyFieldSelection(query, selectedFields);
            }

            return await query.ToListAsync(cancellationToken);
        }

        private IEnumerable<(PropertyInfo Property, string NormalizedName)> GetSelectedFields(IEnumerable<string> fields)
        {
            return fields.Select(field =>
            {
                var normalizedFieldName = field.ToPascalCase();
                var property = typeof(TEntity).GetProperties()
                    .First(p => p.Name.ToPascalCase() == normalizedFieldName);

                return (Property: property, NormalizedName: normalizedFieldName);
            }).Where(x => x.Property != null);
        }

        private IQueryable<TEntity> ApplyFieldSelection(IQueryable<TEntity> query, IEnumerable<(PropertyInfo Property, string NormalizedName)> selectedFields)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "e");

            var bindings = selectedFields.Select(field =>
            {
                var member = Expression.Property(parameter, field.Property);
                return Expression.Bind(field.Property, member);
            }).ToList();

            var memberInit = Expression.MemberInit(Expression.New(typeof(TEntity)), bindings);
            var lambda = Expression.Lambda<Func<TEntity, TEntity>>(memberInit, parameter);

            return query.Select(lambda);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
