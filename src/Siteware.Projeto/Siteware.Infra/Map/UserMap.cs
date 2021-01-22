using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Siteware.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Infra.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id).HasName("Id");
            builder.Property(user => user.Id).HasColumnName("Id").IsRequired();
            builder.Property(user => user.Name).HasColumnName("Name").IsRequired();
            builder.Property(user => user.Email).HasColumnName("Email").IsRequired();
            builder.Property(user => user.LastName).HasColumnName("LastName");
        }
    }
}
