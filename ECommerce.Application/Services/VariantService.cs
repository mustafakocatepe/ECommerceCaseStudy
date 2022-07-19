using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Services
{
    public class VariantService : IVariantService
    {
        private readonly IVariantRepository _variantRepository;
        private readonly IRedisCacheService _redisCacheService;

        public VariantService(IVariantRepository variantRepository, IRedisCacheService redisCacheService)
        {
            _variantRepository = variantRepository;
            _redisCacheService = redisCacheService;
        }
    }
}
