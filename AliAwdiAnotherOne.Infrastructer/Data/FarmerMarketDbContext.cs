using AliAwdiAnotherOne.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AliAwdiAnotherOne
{
    public class AppDbContext : DbContext
    {
        public string DbPath { get; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "market.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<FarmerMarket> FarmerMarkets { get; set; }
        public DbSet<RestaurantOrder> RestaurantOrders { get; set; }
    }
}

