using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Siteware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Infra.Map
{
    public class CartMap : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(user => user.Id).HasName("Id");
            builder.Property(user => user.Id).HasColumnName("Id").IsRequired();
            builder.Property(user => user.Quantity).HasColumnName("Quantity");
            builder.Property(user => user.ProductId).HasColumnName("ProductId").IsRequired();
            builder.Property(user => user.Price).HasColumnName("Price");
            builder.Property(user => user.TotalPrice).HasColumnName("TotalPrice");

        }
    }
}
