using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;

namespace AliAwdiAnotherOne.Application.Commands.FarmerMarketCommands
{
public record DeleteFarmerMarket(int Id) : ICommand<Unit>;
}
