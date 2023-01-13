using Microsoft.EntityFrameworkCore;
using ProductManagement.Data.Database.Contexts;
using ProductManagement.Domain.Core.Contracts.Repositories;
using System.Linq.Expressions;

namespace ProductManagement.Data.Database.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly Lazy<DbSet<TEntity>> _dbSet;

        public Repository(ProductManagementContext dbContext)
        {
            if(dbContext is null)
            {
                throw new ArgumentNullException(nameof(dbContext)); 
            }

            _dbSet = new Lazy<DbSet<TEntity>>(() => dbContext.Set<TEntity>());
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var add = await _dbSet.Value.AddAsync(entity, cancellationToken);
            return add.Entity;
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            var query = _dbSet.Value.Where(expression);
            return await query.FirstOrDefaultAsync();
        }
    }
}
