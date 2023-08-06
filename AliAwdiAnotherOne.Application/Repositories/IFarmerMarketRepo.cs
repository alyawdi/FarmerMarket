
using AliAwdiAnotherOne.Domain.Entities;


namespace AliAwdiAnotherOne.Application.Repositories
{
    public interface IFarmerMarketRepo : IBaseRepository<FarmerMarket>
    {
        public Task<IEnumerable<FarmerMarket>> GetWholeAsync(CancellationToken cancellationToken);
        public Task<FarmerMarket> GetWholeByIdAsync(int id, CancellationToken cancellationToken);
    }
}
