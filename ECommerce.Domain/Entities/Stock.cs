using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int VariantId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Variant Variant { get; set; }
        public Product Product { get; set; }
    }
}
