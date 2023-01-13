using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Core.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
        void Rollback();
    }
}
