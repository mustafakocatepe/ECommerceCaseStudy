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
        private readonly IVariantService _variantService;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public const string StockDetailByVariantCode = "StockDetailByVariantCode:{0}";


        public StockService(IStockRepository stockRepository, IVariantService variantService, IUnitOfWork unitOfWork, IRedisCacheService redisCacheService)
        {
            _stockRepository = stockRepository;
            _variantService = variantService;
            _redisCacheService = redisCacheService;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(CreateStockDto stockDto)
        {
            var variant = await _variantService.Detail(stockDto.VariantCode);

            if (variant == null)
                _stockRepository.Create(stockDto);
            else
            {
                var stock = new Stock()
                {
                    ProductId = variant.ProductId,
                    VariantId = variant.Id,
                    Quantity = stockDto.Quantity,
                };

                await _stockRepository.AddAsync(stock);
            }
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
