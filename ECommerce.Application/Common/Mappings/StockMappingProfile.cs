using AutoMapper;
using ECommerce.Application.Common.DTOs;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common.Mappings
{
    public class StockMappingProfile : Profile
    {
        public StockMappingProfile()
        {
            CreateMap<Stock, StockDto>().ReverseMap();

        }
    }
}
