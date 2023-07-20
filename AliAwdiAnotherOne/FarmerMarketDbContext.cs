using AliAwdiAnotherOne.Models;
using Microsoft.EntityFrameworkCore;


namespace AliAwdiAnotherOne
{
    public class FarmersMarketDbContext : DbContext
    {
        public FarmersMarketDbContext(DbContextOptions<FarmersMarketDbContext> options) : base(options)
        {
        }

        public DbSet<FarmerMarket> FarmerMarkets { get; set; }
    }

}

