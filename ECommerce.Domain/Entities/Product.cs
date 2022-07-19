using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            Stocks = new HashSet<Stock>();
            Variants = new HashSet<Variant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<Variant> Variants { get; set; }

    }
}
