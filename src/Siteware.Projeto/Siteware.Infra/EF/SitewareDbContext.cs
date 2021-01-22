using Microsoft.EntityFrameworkCore;
using Siteware.Domain.Entities;
using Siteware.Infra.Map;

namespace Siteware.Infra.SqlServer.EF
{
    public class SitewareDbContext : DbContext
    {
        public SitewareDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Database.EnsureCreated();
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new PromotionMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConnectionConfig());


            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConnectionConfig()
        {
            string conncetion = "Data Source=limadb.database.windows.net;Initial Catalog=siteware;Integrated Security=false;User ID=limadotnet;Password=Samella2019;Connect Timeout=15;Encrypt=FalseTrustServerCertificate=False";
            return conncetion;
        }
    }
}
