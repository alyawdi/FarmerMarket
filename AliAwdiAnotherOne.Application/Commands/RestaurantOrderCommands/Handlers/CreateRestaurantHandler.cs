using AliAwdiAnotherOne.Application.Repositories;
using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Shared;
using AliAwdiAnotherOne.Domain.Entities;
using Mapster;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace AliAwdiAnotherOne.Application.Commands.RestaurantOrderCommands.Handlers
{
    internal class CreateRestaurantHandler : ICommandHandler<CreateRestaurantOrder, RestaurantDto>
    {
        private readonly IRestaurantOrderRepo _order;
        private readonly IFarmerMarketRepo _farmer;
        private readonly IValidator<RestaurantOrder> _validator;
        public CreateRestaurantHandler(IRestaurantOrderRepo order, IFarmerMarketRepo farmer, IValidator<RestaurantOrder> validator)
        {
            _order = order;
            _farmer = farmer;
            _validator = validator;
        }

        public async Task<Response<RestaurantDto>> Handle(CreateRestaurantOrder command, CancellationToken cancellationToken)
        {
            var (FarmerID, Name, RequiredQuantity) = command;
            //the updating of farmermarket methods
            var farmers = await _farmer.GetWholeByIdAsync(FarmerID, cancellationToken);
            var newQuantity = farmers.OrderItem(farmers.Id);
            farmers.UpdateFarmerMarket(Name,newQuantity);

            RestaurantOrder restaurantOrder = new(Name, RequiredQuantity, 1000);
            //FLuent Validation sobhan allah wal hamdo lleh wla elah ela llah w allah akbar
         
            _=_validator.ValidateAndThrowAsync(restaurantOrder,cancellationToken);

            var newRestaurantOrder = await _order.AddAsync(restaurantOrder, cancellationToken);
            return Response.Success(newRestaurantOrder.Adapt<RestaurantOrder, RestaurantDto>(), " Created user " + newRestaurantOrder.Name + newRestaurantOrder.RequiredQuantity);
        }

 
    }
}
