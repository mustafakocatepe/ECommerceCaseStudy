using ECommerce.Application.Common.DTOs;
using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Repositories;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services
{
    public class VariantService : IVariantService
    {
        private readonly IVariantRepository _variantRepository;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IUnitOfWork _unitOfWork;
        public const string StockDetailByVariantCode = "StockDetailByVariantCode:{0}";

        public VariantService(IVariantRepository variantRepository, IUnitOfWork unitOfWork, IRedisCacheService redisCacheService)
        {
            _variantRepository = variantRepository;
            _redisCacheService = redisCacheService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Variant> Detail(string variantCode) 
        {            
            return _variantRepository.FirstOrDefault(x => x.Code == variantCode);
        }
    }
}
