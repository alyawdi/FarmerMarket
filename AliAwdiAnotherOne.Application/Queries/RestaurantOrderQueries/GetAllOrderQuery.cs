
using AliAwdiAnotherOne.Shared.Abstractions.Application.Queries;
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Application.Repositories;
using AliAwdiAnotherOne.Domain.Entities;
using AliAwdiAnotherOne.Application.Queries.RestaurantOrderQueries.Handlers;
using Mapster;

namespace AliAwdiAnotherOne.Application.Queries.RestaurantOrderQueries
{ 
public record GetAllOrderQuery() : IQuery<List<RestaurantDto>>;

}
