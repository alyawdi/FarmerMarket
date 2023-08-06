using AliAwdiAnotherOne.Shared.Abstractions.Application.Commands;
using AliAwdiAnotherOne.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AliAwdiAnotherOne.Application.Commands.RestaurantOrderCommands.Handlers
{
    internal class CreateRestarurantHandler : ICommandHandler<CreateRestaurantOrder, RestaurantDto>
    {
    }
}
