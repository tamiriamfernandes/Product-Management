using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Core.Contracts.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Data.Database.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext
    {
        private readonly TContext _context;
        public UnitOfWork(TContext context)
        {
            _context= context;
        }

        public Task<int> Commit()
        {
            return _context?.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context?.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}
