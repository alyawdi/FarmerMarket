using AliAwdiAnotherOne.Application.Repositories;
using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Shared;
using AliAwdiAnotherOne.Domain.Entities;

using Mapster;

namespace AliAwdiAnotherOne.Application.Commands.RestaurantOrderCommands.Handlers
{
    internal class CreateRestaurantHandler : ICommandHandler<CreateRestaurantOrder, RestaurantDto>
    {
        private readonly IRestaurantOrderRepo _order;
        private readonly IFarmerMarketRepo _farmer;
        public CreateRestaurantHandler(IRestaurantOrderRepo order, IFarmerMarketRepo farmer)
        {
            _order = order;
            _farmer = farmer;
        }

        public async Task<Response<RestaurantDto>> Handle(CreateRestaurantOrder command, CancellationToken cancellationToken)
        {
            var (FarmerID, Name, RequiredQuantity) = command;
            //the updating of farmermarket methods
            var farmers = await _farmer.GetWholeByIdAsync(FarmerID, cancellationToken);
            var newQuantity = farmers.OrderItem(farmers.Id);
            farmers.UpdateFarmerMarket(Name,newQuantity);

            RestaurantOrder restaurantOrder = new(Name, RequiredQuantity, 1000);
            var newRestaurantOrder = await _order.AddAsync(restaurantOrder, cancellationToken);
            return Response.Success(newRestaurantOrder.Adapt<RestaurantOrder, RestaurantDto>(), " Created user " + newRestaurantOrder.Name + newRestaurantOrder.RequiredQuantity);
        }

 
    }
}
