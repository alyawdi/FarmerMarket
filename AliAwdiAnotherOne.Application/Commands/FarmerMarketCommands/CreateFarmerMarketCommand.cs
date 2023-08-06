using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;

namespace AliAwdiAnotherOne.Application.Commands.FarmerMarketCommands
{
public record CreateFarmerMarket (string newName, int newQuantity) : ICommand<FarmerDto>; 
}
