using ECommerce.Application.Common.DTOs;
using ECommerce.Application.Common.DTOs.Stock;
using ECommerce.Application.Common.Exceptions;
using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Repositories;
using ECommerce.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IVariantService _variantService;
        private readonly IRedisCacheService _redisCacheService;        
        public const string StockDetailByVariantCode = "StockDetailByVariantCode:{0}";
        public const string StockDetailByProductCode = "StockDetailByProductCode:{0}";



        public StockService(IStockRepository stockRepository, IVariantService variantService, IRedisCacheService redisCacheService)
        {
            _stockRepository = stockRepository;
            _variantService = variantService;
            _redisCacheService = redisCacheService;            
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
                    Quantity =  stockDto.Quantity,
                };
                _redisCacheService.Remove(string.Format(StockDetailByVariantCode, stockDto.VariantCode));
                _redisCacheService.Remove(string.Format(StockDetailByProductCode, stockDto.ProductCode));
                await _stockRepository.AddAsync(stock);               
            }
        }

        public async Task<StockDto> GetStockByVariantCodeAsync(string variantCode)
        {
            var cacheKey = string.Format(StockDetailByVariantCode, variantCode);
            var response = _redisCacheService.Get<StockDto>(cacheKey);

            if (response != null)
                return response;

            var stocks = await _stockRepository.GetListAsync(x => x.Variant.Code == variantCode);

            if (stocks.Count <= 0)
                throw new StateException("Stok bulunamadı"); 

            response = new StockDto() { VariantCode = variantCode, Quantity = stocks.Sum(x => x.Quantity) };
            _redisCacheService.Set(cacheKey, response);

            return response;
        }
    }
}
