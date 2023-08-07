using AliAwdiAnotherOne.Application.Repositories;
using AliAwdiAnotherOne.Domain.Entities;
using AliAwdiAnotherOne.Infrastructure.Data.Migrations.Repositories;
using AliAwdiAnotherOne.Infrastructure.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
namespace AliAwdiAnotherOne.Infrastructure.Data.Repositories
{
    internal class FarmerMarketRepository : BaseRepository<FarmerMarket>, IFarmerMarketRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<FarmerMarket> _farmerMarkets;
        public FarmerMarketRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _farmerMarkets = _context.Set<FarmerMarket>();
        }
        public async Task<IEnumerable<FarmerMarket>> GetWholeAsync(CancellationToken cancellationToken)
            => await _farmerMarkets.Include(fm => fm.Name).Include(fm => fm.Quantity).ToListAsync(cancellationToken);

        public async Task<FarmerMarket> GetWholeByIdAsync(int id, CancellationToken cancellationToken)
            => await _farmerMarkets.Include(fm =>fm.Name)
                           .Include(p => p.Quantity)
                           .FirstOrDefaultAsync(p => p.Id == id, cancellationToken)
                ?? throw new NotFoundException(typeof(FarmerMarket).Name, id);

    }
}
