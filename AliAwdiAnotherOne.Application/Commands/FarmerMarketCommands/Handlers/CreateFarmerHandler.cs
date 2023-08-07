using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AliAwdiAnotherOne.Application.Repositories;
using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Shared;
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Application.Repositories;
using AliAwdiAnotherOne.Domain.Entities;
using AliAwdiAnotherOne.Shared;

using Mapster;
namespace AliAwdiAnotherOne.Application.Commands.FarmerMarketCommands.Handlers
{
    internal class CreateFarmerHandler : ICommandHandler<CreateFarmerMarket, FarmerDto>
    {
        private readonly IFarmerMarketRepo _farmerMarket;
        public CreateFarmerHandler(IFarmerMarketRepo FarmerMarket)
        {
            _farmerMarket = FarmerMarket;
        }
        
        public async Task<Response<FarmerDto>> Handle (CreateFarmerMarket request,CancellationToken cancellationToken)
        {
            var (name, quantity) = request;
            FarmerMarket farmerMarket = new (name,quantity);
            var newFarmerMarket = await _farmerMarket.AddAsync(farmerMarket, cancellationToken);
            return Response.Success(newFarmerMarket.Adapt<FarmerMarket, FarmerDto>(), " Created user " + newFarmerMarket.Name + newFarmerMarket.Quantity);
        }
    }
}
