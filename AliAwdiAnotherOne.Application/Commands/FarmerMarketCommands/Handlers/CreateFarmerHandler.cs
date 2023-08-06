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

namespace AliAwdiAnotherOne.Application.Commands.FarmerMarketCommands.Handlers
{
    internal class CreateFarmerHandler : ICommandHandler<CreateFarmerMarket, FarmerDto>
    {
        private readonly IFarmerMarketRepo _farmerMarket;
        public CreateFarmerHandler(IFarmerMarketRepo FarmerMarket)
        {
            _farmerMarket = FarmerMarket;
        }
        
        public async Task<Response<>> Handle (CreateFarmerMarket farmermarket,CancellationToken cancellationToken)
        {
            var (name, quantity) = farmermarket;

            var newFarmerMarket = await _farmerMarket.AddAsync(farmermarket, cancellationToken);
            return Response.Success<>
        }
    }
}
7