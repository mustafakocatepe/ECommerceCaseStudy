using AutoMapper;
using ECommerce.Application.Common.DTOs;
using ECommerce.Application.Common.DTOs.Stock;
using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Repositories;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IMapper _mapper;

        public StockService(IStockRepository stockRepository, IRedisCacheService redisCacheService)
        {
            _stockRepository = stockRepository;
            _redisCacheService = redisCacheService;
        }

        public async Task AddAsync(CreateStockDto stockDto) 
        {
            var stock = _mapper.Map<Stock>(stockDto);
            await _stockRepository.AddAsync(stock);        
        }
    }
}
