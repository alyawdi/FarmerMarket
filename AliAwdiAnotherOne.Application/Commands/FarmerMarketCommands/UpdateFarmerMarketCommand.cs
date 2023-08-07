using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;
using AliAwdiAnotherOne.Application.DTOs;

namespace AliAwdiAnotherOne.Application.Commands.FarmerMarketCommands
{

public record UpdateFarmerMarket(int Id, string NewName, int NewQuantity) : ICommand<FarmerDto>;
}
