using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinance.Infra.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id).HasName("id");
            builder.Property(user => user.Id).HasColumnName("id").IsRequired();
            builder.Property(user => user.Name).HasColumnName("name").IsRequired();
            builder.Property(user => user.Email).HasColumnName("email").IsRequired();
            builder.Property(user => user.Password).HasColumnName("password").IsRequired();
        }
    }
}
