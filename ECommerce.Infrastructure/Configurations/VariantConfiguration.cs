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
            builder
             .HasKey(a => a.Id);

            builder
                .Property(m => m.ProductId)
                .IsRequired();

            builder
                .HasOne(m => m.Product)
                .WithMany(a => a.Variants)
                .HasForeignKey(m => m.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
