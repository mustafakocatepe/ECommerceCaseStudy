using ECommerce.Application.Common.DTOs.Stock;
using ECommerce.Application.Common.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        private readonly ECommerceDbContext _context;
        public StockRepository(ECommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public Stock Create(CreateStockDto createStockDto)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var product =  _context.Set<Product>().Add(new Product() { Code = createStockDto.ProductCode }).Entity;

                    _context.SaveChanges();
                    _context.Update(product); // TO DO

                    var variant =  _context.Set<Variant>().Add(new Variant() { Code = createStockDto.VariantCode, ProductId = product.Id }).Entity;

                    _context.SaveChanges();
                    _context.Update(variant); // TO DO

                    var stock =  _context.Set<Stock>().Add(new Stock()
                    {
                        ProductId = product.Id,
                        VariantId = variant.Id,
                        Quantity = createStockDto.Quantity,
                    }).Entity;

                    _context.SaveChanges();
                    transaction.Commit();

                    return stock;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception { }; //TODO:
                }
            }
        }
    }
}
