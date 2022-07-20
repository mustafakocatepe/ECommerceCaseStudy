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

        public VariantService(IVariantRepository variantRepository)
        {
            _variantRepository = variantRepository;            
        }

        public async Task<Variant> Detail(string variantCode) 
        {            
            return _variantRepository.FirstOrDefault(x => x.Code == variantCode);
        }
    }
}
