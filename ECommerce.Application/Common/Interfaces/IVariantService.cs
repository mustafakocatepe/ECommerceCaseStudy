using ECommerce.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Common.Interfaces
{
    public interface IVariantService
    {
        Task AddAsync(string productCode);
    }
}
