using ECommerce.Application.Common.DTOs;
using ECommerce.Application.Common.Exceptions;
using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Repositories;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IRedisCacheService _redisCacheService;
        public const string StockDetailByProductCode = "StockDetailByProductCode:{0}";

        public ProductService(IProductRepository productRepository,  IRedisCacheService redisCacheService)
        {
            _productRepository = productRepository;
            _redisCacheService = redisCacheService;
        }

        public async Task<List<StockDto>> GetStocksByProductCodeAsync(string productCode)
        {
            var cacheKey = string.Format(StockDetailByProductCode, productCode);
            var response = _redisCacheService.Get<List<StockDto>>(cacheKey);

            if (response != null)
                return response;

            response = _productRepository.FirstOrDefault(x => x.Code == productCode)
                        .Stocks
                        .Select(x => new StockDto { Quantity = x.Quantity, VariantCode = x.Variant.Code })                        
                        .GroupBy(x => x.VariantCode)
                        .Select(g => new StockDto { VariantCode = g.Key, Quantity = g.Sum(s => s.Quantity) })
                        .ToList();

            if (response.Count <= 0)
                throw new StateException("Stok bulunamadı");

            _redisCacheService.Set(cacheKey, response);

            return response;
        }

    }
}
