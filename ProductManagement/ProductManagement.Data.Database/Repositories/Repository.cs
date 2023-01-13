using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using ProductManagement.Data.Database.Contexts;
using ProductManagement.Domain.Core.Contracts.Repositories;
using ProductManagement.Domain.Core.Models;
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
            return await _dbSet.Value.AsQueryable().Where(expression).FirstOrDefaultAsync();
        }

        public async Task<PaginatedList<TEntity>> GetPaginatedAsync(Expression<Func<TEntity, bool>> expression, int page, int pageSize)
        {
            var query = _dbSet.Value.AsQueryable().Where(expression);

            var items = await query.Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
            var total = await query.CountAsync();

            return new PaginatedList<TEntity>(items, total, page, pageSize);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Value.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Value.Remove(entity);
        }
    }
}
