using ECommerce.Application.Common.DTOs.Stock;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Common.Repositories
{
    public interface IStockRepository : IRepository<Stock>
    {
        void Create(CreateStockDto createStockDto);
    }
}
