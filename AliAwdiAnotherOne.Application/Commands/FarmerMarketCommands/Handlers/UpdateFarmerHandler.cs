
using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Shared;
using AliAwdiAnotherOne.Domain.Entities;
using AliAwdiAnotherOne.Application.Repositories;
using Mapster;
using FluentValidation;

namespace AliAwdiAnotherOne.Application.Commands.FarmerMarketCommands.Handlers
{
    internal class UpdateFarmerHandler : ICommandHandler<UpdateFarmerMarket, FarmerDto>
    {
        private readonly IFarmerMarketRepo _farmer;
        private readonly IValidator<FarmerMarket> _validator;
        public UpdateFarmerHandler(IFarmerMarketRepo farmer,IValidator<FarmerMarket> validator)
        {
            _farmer = farmer;
            _validator = validator;
        }

        public async Task<Response<FarmerDto>> Handle(UpdateFarmerMarket request, CancellationToken cancellationToken)
        {
            var (Id, name, quantity) = request;
            FarmerMarket farmermarket = new(name, quantity);
            _ = _validator.ValidateAndThrowAsync(farmermarket, cancellationToken);

            var updatedFarmer = await _farmer.UpdateAsync(farmermarket, cancellationToken);
            return Response.Success(updatedFarmer.Adapt<FarmerMarket, FarmerDto>(), "Updated user " + updatedFarmer.Name + updatedFarmer.Quantity);
        }
    }
}
