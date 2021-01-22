using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Siteware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Infra.Map
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(product => product.Id).HasName("Id");
            builder.Property(product => product.Id).HasColumnName("Id").IsRequired();
            builder.Property(product => product.Name).HasColumnName("Name").IsRequired();
            builder.Property(product => product.Price).HasColumnName("Price").IsRequired().HasColumnType("decimal");
            builder.Property(product => product.PromotionId).HasColumnName("PromotionId");
        }
    }
}
