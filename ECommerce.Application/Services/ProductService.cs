using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IRedisCacheService _redisCacheService;
        public ProductService(IProductRepository productRepository, IRedisCacheService redisCacheService)
        {
            _productRepository = productRepository;
            _redisCacheService = redisCacheService;
        }

    }
}
