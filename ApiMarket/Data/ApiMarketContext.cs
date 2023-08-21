using ApiMarket.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ApiMarket.Data
{
    public class ApiMarketContext : DbContext
    {
        public ApiMarketContext(DbContextOptions<ApiMarketContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseLazyLoadingProxies();





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ClientArticle>()
                .Property(x => x.DateUpdate)
                .HasColumnType("datetime");

            modelBuilder
               .Entity<StoreArticle>()
               .Property(x => x.DateUpdate)
               .HasColumnType("datetime");


        }

        public DbSet<ApiMarket.Models.Article>? Article { get; set; } = default!;

        public DbSet<ApiMarket.Models.Store>? Store { get; set; }

        public DbSet<ApiMarket.Models.Client>? Client { get; set; }

        public DbSet<ApiMarket.Models.ClientArticle>? ClientArticle { get; set; }

        public DbSet<ApiMarket.Models.StoreArticle>? StoreArticle { get; set; }
    }
}
