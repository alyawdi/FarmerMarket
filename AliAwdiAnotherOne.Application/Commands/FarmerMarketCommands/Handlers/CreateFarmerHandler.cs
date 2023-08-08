using AliAwdiAnotherOne.Application.Repositories;
using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Shared;
using AliAwdiAnotherOne.Domain.Entities;
using FluentValidation;
using Mapster;

using FluentValidation.Results;

namespace AliAwdiAnotherOne.Application.Commands.FarmerMarketCommands.Handlers
{
    internal class CreateFarmerHandler : ICommandHandler<CreateFarmerMarket, FarmerDto>
    {
        private readonly IFarmerMarketRepo _farmerMarket;
        private readonly IValidator<FarmerMarket> _validator;
        public CreateFarmerHandler(IFarmerMarketRepo FarmerMarket ,IValidator<FarmerMarket> validator)
        {
            _farmerMarket = FarmerMarket;
            _validator = validator;
        }

        public async Task<Response<FarmerDto>> Handle(CreateFarmerMarket request, CancellationToken cancellationToken)
        {

            var (name, quantity) = request;
            FarmerMarket farmerMarket = new(name, quantity);
            //ValidationResult result= await _validator.ValidateAsync(farmerMarket, cancellationToken);
            // i don't know if i'm missing up but according to the function documentation it do the same thing 
            //and the _=_ is just to remove the warning 
            _=_validator.ValidateAndThrowAsync(farmerMarket, cancellationToken);



            var newFarmerMarket = await _farmerMarket.AddAsync(farmerMarket, cancellationToken);
            return Response.Success(newFarmerMarket.Adapt<FarmerMarket, FarmerDto>(), " Created user " + newFarmerMarket.Name + newFarmerMarket.Quantity);
        }
    }
}
