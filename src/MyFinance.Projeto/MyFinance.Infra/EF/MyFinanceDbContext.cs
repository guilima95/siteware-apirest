using Microsoft.EntityFrameworkCore;
using MyFinance.Domain.Entities;
using MyFinance.Infra.Map;

namespace MyFinance.Infra.SqlServer.EF
{
    public class MyFinanceDbContext : DbContext
    {
        public MyFinanceDbContext(DbContextOptions<MyFinanceDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Finance> Finance { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new FinanceMap());
        }
    }
}
