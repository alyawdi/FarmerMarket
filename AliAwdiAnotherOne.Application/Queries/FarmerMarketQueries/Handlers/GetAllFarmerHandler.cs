using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Application.Repositories;
using AliAwdiAnotherOne.Domain.Entities;
using AliAwdiAnotherOne.Shared.Abstractions.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;

namespace AliAwdiAnotherOne.Application.Queries.FarmerMarketQueries.Handlers
{
    internal class GetAllFarmerHandler : IQueryHandler<GetAllFarmerQuery, List<FarmerDto>>
    {
        private readonly IFarmerMarketRepo _farmer;
        public GetAllFarmerHandler(IFarmerMarketRepo farmer)
        {
            _farmer = farmer;
        }
        public async Task<List<FarmerDto>> Handle(GetAllFarmerQuery request, CancellationToken cancellationToken)
        {
            var farmers = await _farmer.GetWholeAsync(cancellationToken);
            return farmers.Adapt<IEnumerable<FarmerMarket>, IEnumerable<FarmerDto>>().ToList();
        }
    }
}

