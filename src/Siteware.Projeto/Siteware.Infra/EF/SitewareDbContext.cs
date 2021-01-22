using Microsoft.EntityFrameworkCore;
using Siteware.Domain.Entities;
using Siteware.Infra.Map;

namespace Siteware.Infra.SqlServer.EF
{
    public class SitewareDbContext : DbContext
    {
        public SitewareDbContext(DbContextOptions<SitewareDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Product> Product { get; set; }
        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Maps
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new PromotionMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
