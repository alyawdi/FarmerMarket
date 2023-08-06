using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Shared.Abstractions.Application.Queries;


namespace AliAwdiAnotherOne.Application.Queries.FarmerMarketQueries
{
    internal record GetByIDFarmerQuery (int Id): IQuery<FarmerDto>;
  
}
