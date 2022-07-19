using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Configurations
{
    internal class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();


            builder
                .HasOne(x => x.Product)
                .WithMany(y => y.Stocks)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(m => m.VariantId)
                .IsRequired();


            builder.Property(m => m.Quantity).HasDefaultValue(0);
            builder.Property(m => m.CreatedDate).HasDefaultValue(DateTime.Now);
            builder.Property(m => m.UpdatedDate).HasDefaultValue("0001.01.01");

            builder.HasData(Data());
        }

        IEnumerable<Stock> Data()
        {
            return new List<Stock>
            {
                new Stock
                {
                    Id = 1,
                    Quantity = 10,
                    CreatedDate= DateTime.Now,
                    ProductId =1,
                    VariantId =1 
                },
                new Stock
                {
                    Id = 2,
                    Quantity = 15,
                    CreatedDate= DateTime.Now,
                    ProductId =1,
                    VariantId =2
                }
            };
        }
    }
}
