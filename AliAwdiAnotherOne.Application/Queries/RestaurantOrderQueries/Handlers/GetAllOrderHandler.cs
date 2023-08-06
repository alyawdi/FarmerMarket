
using AliAwdiAnotherOne.Shared.Abstractions.Application.Queries;
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Application.Repositories;
using AliAwdiAnotherOne.Domain.Entities;
using AliAwdiAnotherOne.Application.Queries.RestaurantOrderQueries;
using Mapster;
namespace AliAwdiAnotherOne.Application.Queries.RestaurantOrderQueries.Handlers
{
    public class GetAllOrderHandler : IQueryHandler<GetAllOrderQuery, List<RestaurantDto>>
    {
        private readonly IRestaurantOrderRepo _order;
        public GetAllOrderHandler (IRestaurantOrderRepo order) { 
        _order = order;
        }
        public async Task<List<RestaurantDto>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await _order.GetWholeAsync(cancellationToken);
            return orders.Adapt<IEnumerable<RestaurantOrder>, IEnumerable<RestaurantDto>>().ToList();
        }
    }
}
