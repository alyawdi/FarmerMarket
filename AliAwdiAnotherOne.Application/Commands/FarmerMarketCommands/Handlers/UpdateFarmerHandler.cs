
using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Shared;
using AliAwdiAnotherOne.Domain.Entities;
using AliAwdiAnotherOne.Application.Repositories;
using Mapster;
namespace AliAwdiAnotherOne.Application.Commands.FarmerMarketCommands.Handlers
{
    internal class UpdateFarmerHandler : ICommandHandler<UpdateFarmerMarket, FarmerDto>
    {
        private readonly IFarmerMarketRepo _farmer;

        public UpdateFarmerHandler(IFarmerMarketRepo farmer)
        {
            _farmer = farmer;
        }

        public async Task<Response<FarmerDto>> Handle(UpdateFarmerMarket request, CancellationToken cancellationToken)
        {
            var (Id, name, quantity) = request;
            FarmerMarket farmermarket = new(name, quantity);
            var updatedFarmer = await _farmer.UpdateAsync(farmermarket, cancellationToken);
            return Response.Success(updatedFarmer.Adapt<FarmerMarket, FarmerDto>(), "Updated user " + updatedFarmer.Name + updatedFarmer.Quantity);
        }
    }
}
