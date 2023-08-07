using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;
using   AliAwdiAnotherOne.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliAwdiAnotherOne.Application.Commands.FarmerMarketCommands;
using AliAwdiAnotherOne.Application.Repositories;
using AliAwdiAnotherOne.Shared;
using MediatR;
using Mapster;

namespace AliAwdiAnotherOne.Application.Commands.RestaurantOrderCommands.Handlers
{
    internal class DeleteRestaurantHandler : ICommandHandler<DeleteRestaurantOrder, Unit>
    {
        private readonly IRestaurantOrderRepo _order;


        public DeleteRestaurantHandler(IRestaurantOrderRepo order)
        {
            _order = order;
        }

        public async Task<Response<Unit>> Handle(DeleteRestaurantOrder request, CancellationToken cancellationToken)
        {// note: you should check the exception of not finding any farmer with this id

            await _order.DeleteAsync(request.Id, cancellationToken);
            return Response.Success(Unit.Value, "Deleted user");

        }
    }
}
