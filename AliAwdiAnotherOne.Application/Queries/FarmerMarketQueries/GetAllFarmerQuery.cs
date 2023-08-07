using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Shared.Abstractions.Application.Queries;

namespace AliAwdiAnotherOne.Application.Queries.FarmerMarketQueries
{
    public record GetAllFarmerQuery ():IQuery<List<FarmerDto>>;
    
}
