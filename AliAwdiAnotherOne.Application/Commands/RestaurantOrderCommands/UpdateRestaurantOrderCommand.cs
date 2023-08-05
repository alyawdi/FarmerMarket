using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliAwdiAnotherOne.Application.Commands.RestaurantOrderCommands
{
public record UpdateRestaurantOrder (int Id, string newName, int newQuantity);
}
