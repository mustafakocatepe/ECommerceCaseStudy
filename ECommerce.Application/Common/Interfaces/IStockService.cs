using ECommerce.Application.Common.DTOs.Stock;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Common.Interfaces
{
    public interface IStockService
    {
        Task AddAsync(CreateStockDto stockDto);
    }
}
