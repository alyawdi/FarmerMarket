
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Shared.Abstractions.Application.Queries;

namespace AliAwdiAnotherOne.Application.Queries.RestaurantOrderQueries
{
   public record GetByIDOrderQuery (int Id): IQuery<RestaurantDto>;
}
