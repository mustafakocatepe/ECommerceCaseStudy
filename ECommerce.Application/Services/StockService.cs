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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public const string StockDetailByVariantCode = "StockDetailByVariantCode:{0}";


        public StockService(IStockRepository stockRepository, IUnitOfWork unitOfWork, IRedisCacheService redisCacheService)
        {
            _stockRepository = stockRepository;
            _redisCacheService = redisCacheService;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(CreateStockDto stockDto)
        {
            var stock = new Stock()
            {
                Product = new Product() { Code = stockDto.ProductCode },
                Variant = new Variant() { Code = stockDto.VariantCode },
                Quantity = stockDto.Quantity
            };
            await _stockRepository.AddAsync(stock);
            _unitOfWork.Commit();
        }

        public async Task<StockDto> GetStockByVariantCodeAsync(string variantCode)
        {
            var cacheKey = string.Format(StockDetailByVariantCode, variantCode);
            var response = _redisCacheService.Get<StockDto>(cacheKey);

            if (response != null)
                return response;

            var stock = _stockRepository.FirstOrDefaultAsync(x => x.Variant.Code == variantCode).Result;

            if (stock == null)
                return null; // TO DO

            response = new StockDto() { Id = stock.Id, Quantity = stock.Quantity };
            _redisCacheService.Set(cacheKey, response);

            return response;
        }
    }
}
