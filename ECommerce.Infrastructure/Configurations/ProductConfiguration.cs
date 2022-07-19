using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Code).HasMaxLength(50).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(50).IsRequired();
            builder.Property(t => t.CreatedDate).HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(t => t.IsActive).HasDefaultValue(true).IsRequired();
        }
    }
}
