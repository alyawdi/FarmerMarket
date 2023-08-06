using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AliAwdiAnotherOne.Application.Commands.RestaurantOrderCommands
{
public record DeleteRestaurantOrder(int Id): ICommand<Unit>;
}
