using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;
using AliAwdiAnotherOne.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AliAwdiAnotherOne.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AliAwdiAnotherOne.Application.Repositories;
using AliAwdiAnotherOne.Application.Commands;
using AliAwdiAnotherOne.Shared;
using AliAwdiAnotherOne.Application.Commands.FarmerMarketCommands;
using MediatR;

namespace AliAwdiAnotherOne.Application.Commands.RestaurantOrderCommands.Handlers
{
    internal class CreateRestarurantHandler : ICommandHandler<CreateRestaurantOrder, RestaurantDto>
    {
        private readonly IRestaurantOrderRepo _order;
        private readonly IFarmerMarketRepo _farmer;
        public CreateRestarurantHandler(IRestaurantOrderRepo order, IFarmerMarketRepo farmer)
        {
            _order = order;
            _farmer = farmer;
        }

        public async Task<Response<FarmerDto>> Handle(CreateRestaurantOrder command, CancellationToken cancellationToken)
        {
            var (name, requiredQuantity, cost) = command;
            var farmers = await _farmer.GetWholeByIdAsync(Id, cancellationToken);
            var newQuantity = farmers.OrderItem(farmers.Id);
            farmers.UpdateFarmerMarket(newQuantity);

            RestaurantOrder restaurantOrder = new(name, requiredQuantity, 1000);
            var newRestaurantOrder = await _order.AddAsync(restaurantOrder, cancellationToken);
            return Response.Success(newRestaurantOrder.Adapt<RestaurantOrder, RestaurantDto>(), " Created user " + newRestaurantOrder.Name + newRestaurantOrder.requiredQuantity);
        }

        Task<Response<RestaurantDto>> IRequestHandler<CreateRestaurantOrder, Response<RestaurantDto>>.Handle(CreateRestaurantOrder request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
