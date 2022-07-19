using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IRedisCacheService _redisCacheService;

        public StockService(IStockRepository stockRepository, IRedisCacheService redisCacheService)
        {
            _stockRepository = stockRepository;
            _redisCacheService = redisCacheService;
        }
    }
}
