using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void BeginTransaction();
        void Commit();
        void Rollback();
        bool IsTransactionContinue();
    }
}
