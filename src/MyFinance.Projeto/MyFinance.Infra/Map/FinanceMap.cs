using MyFinance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyFinance.Infra.Map
{
    public class FinanceMap : IEntityTypeConfiguration<Finance>
    {
        public void Configure(EntityTypeBuilder<Finance> builder)
        {
            builder.HasKey(finance => finance.Id).HasName("id");
            builder.Property(finance => finance.Id).HasColumnName("id").IsRequired();
            builder.Property(finance => finance.Amount).HasColumnName("amount").IsRequired();
            builder.Property(finance => finance.Date).HasColumnName("date").IsRequired();
            builder.Property(finance => finance.Description).HasColumnName("description").IsRequired();
            builder.Property(finance => finance.Frequency).HasColumnName("frequency").IsRequired();
            builder.Property(finance => finance.Type).HasColumnName("type").IsRequired();
            builder.HasOne<User>().WithMany().HasForeignKey(finance => finance.UserId);
        }
    }
}

