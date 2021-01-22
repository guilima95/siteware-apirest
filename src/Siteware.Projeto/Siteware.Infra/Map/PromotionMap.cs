using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Siteware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Infra.Map
{
    public class PromotionMap : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.ToTable("Promotion");
            builder.HasKey(pro => pro.Id).HasName("Id");
            builder.Property(pro => pro.Description).HasColumnName("Description");
            builder.Property(pro => pro.ProductId).HasColumnName("ProductId");
            builder.Property(pro => pro.Validity).HasColumnName("Validity").HasColumnType("datetime");
        }
    }
}
