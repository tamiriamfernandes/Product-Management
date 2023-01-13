using ProductManagement.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Core.Contracts.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        Task<PaginatedList<TEntity>> GetPaginatedAsync(Expression<Func<TEntity, bool>> expression, int page, int pageSize);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
