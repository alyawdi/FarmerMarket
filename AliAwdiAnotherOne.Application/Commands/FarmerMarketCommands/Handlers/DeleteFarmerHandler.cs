using AliAwdiAnotherOne.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;
using AliAwdiAnotherOne.Application.Commands.FarmerMarketCommands;
using AliAwdiAnotherOne.Application.Repositories;

namespace AliAwdiAnotherOne.Application.Commands.PostCommands.Handlers
{
    internal class DeleteFarmerHandler : ICommandHandler<DeleteFarmerMarket, Unit>
    {
        private readonly IFarmerMarketRepo _farmer;


        public DeleteFarmerHandler(IFarmerMarketRepo farmer)
        {
            _farmer = farmer;
        }

        public async Task<Response<Unit>> Handle(DeleteFarmerMarket request, CancellationToken cancellationToken)
        {// note: you should check the exception of not finding any farmer with this id
         
                await _farmer.DeleteAsync(request.Id, cancellationToken);
                return Response.Success(Unit.Value, "Deleted user");
            
        }
    }
}