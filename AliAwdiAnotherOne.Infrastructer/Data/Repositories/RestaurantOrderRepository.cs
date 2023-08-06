/*using AliAwdiAnotherOne.Application.Repository;
*/using AliAwdiAnotherOne.Application.Repositories;
using AliAwdiAnotherOne.Domain.Entities;
using AliAwdiAnotherOne.Infrastructure.Data.Migrations.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AliAwdiAnotherOne.Infrastructure.Data.Repositories
{
    internal class RestaurantOrderRepository : BaseRepository<RestaurantOrder>, IRestaurantOrderRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<RestaurantOrder> _RestaurantOrders;
        public RestaurantOrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _RestaurantOrders = _context.Set<RestaurantOrder>();
        }
        public async Task<IEnumerable<RestaurantOrder>> GetWholeAsync(CancellationToken cancellationToken)
            => await _RestaurantOrders.Include(ro => ro.Name).Include(ro =>ro.RequiredQuantity ).ToListAsync(cancellationToken);

        public async Task<RestaurantOrder> GetWholeByIdAsync(int id, CancellationToken cancellationToken)
            => await _RestaurantOrders.Include(ro =>ro.Name)
                           .Include(p => p.RequiredQuantity)
                           .FirstOrDefaultAsync(p => p.Id == id, cancellationToken)
                ?? throw new NotFoundException(typeof(RestaurantOrder).Name, id);

    }
}
