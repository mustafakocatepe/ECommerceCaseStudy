using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common.DTOs.Stock
{
    public class CreateStockDto
    {
        public string VariantCode { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
