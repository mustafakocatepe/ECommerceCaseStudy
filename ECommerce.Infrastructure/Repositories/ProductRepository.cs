using ECommerce.Application.Common.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ECommerceDbContext _context;
        public ProductRepository(ECommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public override Product FirstOrDefault(Expression<Func<Product, bool>> predicate)
        {
            var response =  _context.Set<Product>()
                    .Include(x => x.Stocks)
                    .ThenInclude(x=> x.Variant)
                    .AsNoTracking()
                    .AsQueryable()                    
                    .FirstOrDefault(predicate);

            return response;
        }
    }
}
