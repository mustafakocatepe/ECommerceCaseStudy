using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common.DTOs
{
    public class StockDto
    {
        public string VariantCode { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
