using ECommerce.Application.Common.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Repositories
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        private readonly ECommerceDbContext _context;
        public StockRepository(ECommerceDbContext context) : base(context)
        {
            _context = context;
        }
    }   
}
