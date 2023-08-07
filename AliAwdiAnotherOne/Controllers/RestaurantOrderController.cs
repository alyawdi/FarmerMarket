/*using AliAwdiAnotherOne.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AliAwdiAnotherOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ResturantsOrdersController : ControllerBase
    {
        private readonly ILogger<ResturantsOrdersController> _logger;
        private readonly AppDbContext _context;

        public ResturantsOrdersController(ILogger<ResturantsOrdersController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<RestaurantOrder>> GetAsync()
        {
            _logger.LogInformation("You fetched all the restaurant orders.");
            return await _context.RestaurantOrders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<RestaurantOrder> GetByIdAsync(int id)
        {
            _logger.LogInformation($"You fetched the restaurant order with the following ID: {id}");
            return await _context.RestaurantOrders.FirstOrDefaultAsync(order => order.Id == id) ?? throw new Exception("Order not found.");
        }

        [HttpPost]
        public async Task<RestaurantOrder> CreateAsync(string itemName, int orderedQuantity, int cost)
        {

            var requestedItem = await _context.FarmerMarkets.FirstOrDefaultAsync(fm => fm.Name == itemName) ?? throw new Exception("The name you're ordering isn't found please make sure of it");
            var newQuantity = requestedItem.OrderItem(orderedQuantity);
            _context.Update(requestedItem);

            var order = new RestaurantOrder(itemName, newQuantity, cost);
            _context.RestaurantOrders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        [HttpPut]
        public async Task<RestaurantOrder> UpdateAsync(int id, string newItemName, int newOrderedQuantity)
        {
            var order = await _context.RestaurantOrders.FirstOrDefaultAsync(o => o.Id == id) ?? throw new Exception("Order not found.");
            var requestedItem = await _context.FarmerMarkets.FirstOrDefaultAsync(fm => fm.Name == newItemName) ?? throw new Exception("The name you're ordering isn't found please make sure of it");
            var newQuantity = requestedItem.OrderItem(newOrderedQuantity);
            _context.Update(requestedItem);
            order.UpdateRestaurantOrder(newItemName, newQuantity);
            _context.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var order = await _context.RestaurantOrders.FirstOrDefaultAsync(o => o.Id == id);
            if (order is null)
                return NotFound();

            _context.RestaurantOrders.Remove(order);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
*/
using AliAwdiAnotherOne.Application.DTOs;
using AliAwdiAnotherOne.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AliAwdiAnotherOne.Application.Commands.RestaurantOrderCommands;
using AliAwdiAnotherOne.Application.Queries.RestaurantOrderQueries;
using AliAwdiAnotherOne.Shared;
namespace AliAwdiAnotherOne.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantOrderController : ControllerBase
    {


        private readonly IMediator _mediator;

        public RestaurantOrderController (IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        public async Task<List<RestaurantDto>> Get([FromQuery] GetAllOrderQuery query, CancellationToken cancellationToken)
            => await _mediator.Send(query, cancellationToken);

        [HttpGet("byId")]
        public async Task<RestaurantDto> Get([FromQuery] GetByIDOrderQuery query, CancellationToken cancellationToken)
            => await _mediator.Send(query, cancellationToken);

        [HttpPost]
        public async Task<Response<RestaurantDto>> Post(CreateRestaurantOrder command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpPut]
        public async Task<Response<RestaurantDto>> Put(UpdateRestaurantOrder command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);

        [HttpDelete]
        public async Task Delete(DeleteRestaurantOrder command, CancellationToken cancellationToken)
            => await _mediator.Send(command, cancellationToken);
    }
}
