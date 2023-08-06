using AliAwdiAnotherOne.Domain.Entities;

namespace AliAwdiAnotherOne.Application.Repositories
{
    public interface IRestaurantOrderRepo : IBaseRepository<RestaurantOrder>
    {
        public Task<IEnumerable<RestaurantOrder>> GetWholeAsync(CancellationToken cancellationToken);
        public Task<RestaurantOrder> GetWholeByIdAsync(int id, CancellationToken cancellationToken);
    }
}
