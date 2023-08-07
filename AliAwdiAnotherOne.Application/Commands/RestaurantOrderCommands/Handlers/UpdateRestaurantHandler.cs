using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Application.Commands.RestaurantOrderCommands;
using AliAwdiAnotherOne.Application.Repositories;
using AliAwdiAnotherOne.Domain.Entities;
using AliAwdiAnotherOne.Shared;
using Mapster;
using System.Xml.Linq;

namespace AliAwdiAnotherOne.Application.Commands.RestaurantOrderCommands.Handlers
{
    internal class UpdateRestaurantHandler : ICommandHandler<UpdateRestaurantOrder, RestaurantDto>
    {
        private readonly IRestaurantOrderRepo _order;
        private readonly IFarmerMarketRepo _farmer;
        public UpdateRestaurantHandler(IRestaurantOrderRepo order, IFarmerMarketRepo farmer)
        {
            _order = order;
            _farmer = farmer;   
        }
        public async Task<Response<RestaurantDto>> Handle(UpdateRestaurantOrder request, CancellationToken cancellationToken)
        {
            var (TargetedId, newName, newQuantity, FarmerId) = request;
            var farmers = await _farmer.GetWholeByIdAsync(FarmerId, cancellationToken);
            var newQuantity = farmers.OrderItem(farmers.Id);
            farmers.UpdateFarmerMarket(farmers.Name, newQuantity);

            RestaurantOrder restaurantOrder = new(newName, newQuantity,1000);
            var UpdateOrder = await _order.UpdateAsync(restaurantOrder, cancellationToken);
            return Response.Success(UpdateOrder.Adapt<RestaurantOrder, RestaurantDto>(), "Updated user " + UpdateOrder.Name + UpdateOrder.RequiredQuantity);

        }
    }
}
