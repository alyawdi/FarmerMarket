using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;
using AliAwdiAnotherOne.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliAwdiAnotherOne.Application.Commands.RestaurantOrderCommands
{
public record UpdateRestaurantOrder (int targetedId, string NewName, int NewQuantity, int FarmerId) : ICommand<RestaurantDto>;
}
