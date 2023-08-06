using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Application.Repositories;
using AliAwdiAnotherOne.Shared.Abstractions.Application.Queries;
using AliAwdiAnotherOne.Domain.Entities;

using Mapster;

namespace AliAwdiAnotherOne.Application.Queries.FarmerMarketQueries.Handlers
{
    internal class GetByIDFarmerHandler : IQueryHandler<GetByIDFarmerQuery, FarmerDto>
{
    
        private readonly IFarmerMarketRepo _farmer;

        public GetByIDFarmerHandler(IFarmerMarketRepo farmer)
        {
        _farmer = farmer;
        }

        public async Task<FarmerDto> Handle(GetByIDFarmerQuery request, CancellationToken cancellationToken)
        {
            var farmers = await _farmer.GetWholeByIdAsync(request.Id, cancellationToken);
            return farmers.Adapt<FarmerMarket, FarmerDto>();
        }

    }
}
