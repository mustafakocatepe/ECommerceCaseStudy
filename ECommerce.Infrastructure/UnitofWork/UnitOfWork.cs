using ECommerce.Application.Common.Interfaces;
using ECommerce.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ECommerceDbContext Context { get; internal set; }
        private bool isTransaction { get; set; }

        public UnitOfWork(ECommerceDbContext context)
        {
            Context = context;
        }

        public void BeginTransaction()
        {
            Context.Database.BeginTransaction();
            isTransaction = true;
        }

        public void Commit()
        {
            Context.Database.CommitTransaction();
            isTransaction = false;
        }

        public bool IsTransactionContinue()
        {
            return isTransaction;
        }

        public void Rollback()
        {
            Context.Database.RollbackTransaction();
            isTransaction = false;
        }

        public Task<int> SaveChanges()
        {
            return Context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }
    }
}
