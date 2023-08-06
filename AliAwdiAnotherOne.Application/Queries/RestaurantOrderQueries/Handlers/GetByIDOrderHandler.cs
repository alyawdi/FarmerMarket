using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Application.Repositories;
using AliAwdiAnotherOne.Domain.Entities;
using AliAwdiAnotherOne.Shared.Abstractions.Application.Queries;
using Mapster;
namespace AliAwdiAnotherOne.Application.Queries.RestaurantOrderQueries.Handlers
{
    internal class GetByIDOrderHandler : IQueryHandler<GetByIDOrderQuery,RestaurantDto>
    {
        private readonly IRestaurantOrderRepo _order;

        public GetByIDOrderHandler(IRestaurantOrderRepo order)
        {
            _order = order;
        }

        public async Task<RestaurantDto> Handle(GetByIDOrderQuery request, CancellationToken cancellationToken)
        {
            var orders = await _order.GetWholeByIdAsync(request.Id, cancellationToken);
            return orders.Adapt<RestaurantOrder, RestaurantDto>();
        }
    }
}
