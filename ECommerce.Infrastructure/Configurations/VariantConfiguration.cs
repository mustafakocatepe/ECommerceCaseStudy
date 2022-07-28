using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Configurations
{
    internal class VariantConfiguration : IEntityTypeConfiguration<Variant>
    {
        public void Configure(EntityTypeBuilder<Variant> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductId).IsRequired();

            builder
                .HasOne(m => m.Product)
                .WithMany(a => a.Variants)
                .HasForeignKey(m => m.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(Data());

        }

        IEnumerable<Variant> Data()
        {
            return new List<Variant>
            {
                new Variant
                {
                    Id = 1,
                    Name  = "Renk Mavi",
                    CreatedDate= DateTime.Now,
                    Code = "1000000851096",
                    ProductId = 1,                     
                },
                new Variant
                {
                    Id = 2,
                    Name  = "Renk Kirmizi",
                    CreatedDate= DateTime.Now,
                    Code = "1000000851097",
                    ProductId = 1,

                }
            };
        }
    }
}
