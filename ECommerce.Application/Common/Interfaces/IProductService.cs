using ECommerce.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Common.Interfaces
{
    public interface IProductService
    {
        Task AddAsync(string productCode);
        Task<List<StockDto>> GetStocksByProductCodeAsync(string productCode);
    }
}
