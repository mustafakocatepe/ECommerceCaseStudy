using AutoMapper;
using ECommerce.Application.Common.DTOs;
using ECommerce.Application.Common.DTOs.Stock;
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

        public async Task<Stock> AddAsync(CreateStockDto stockDto)
        {
            var variant = await _variantService.Detail(stockDto.VariantCode);

            if (variant == null)
                return _stockRepository.Create(stockDto);
            else
            {
                var stock = new Stock()
                {
                    ProductId = variant.ProductId,
                    VariantId = variant.Id,
                    Quantity = stockDto.Quantity,
                };

                await _stockRepository.AddAsync(stock);
                return stock;
            }
        }

        public async Task<StockDto> GetStockByVariantCodeAsync(string variantCode)
        {
            var cacheKey = string.Format(StockDetailByVariantCode, variantCode);
            var response = _redisCacheService.Get<StockDto>(cacheKey);

            if (response != null)
                return response;

            var stocks = await _stockRepository.GetListAsync(x => x.Variant.Code == variantCode);            

            if (stocks == null)
                return null; // TO DO

            response = new StockDto() { VariantCode = variantCode, Quantity = stocks.Sum(x => x.Quantity) };
            _redisCacheService.Set(cacheKey, response);

            return response;
        }
    }
}
