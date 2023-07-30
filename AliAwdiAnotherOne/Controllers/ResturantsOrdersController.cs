using AliAwdiAnotherOne.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace AliAwdiAnotherOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ResturantsOrdersController : ControllerBase
    {
        private readonly ILogger<ResturantsOrdersController> _logger;
        private readonly ResturantOrderDbContext _context;
        private readonly FarmerMarketController _farmermarketcontroller;

        public ResturantsOrdersController(ILogger<ResturantsOrdersController> logger, ResturantOrderDbContext context, FarmerMarketController farmermarketcontroller)
        {
            _logger = logger;
            _context = context;
            _farmermarketcontroller = farmermarketcontroller;
        }


        [HttpGet]
        public async Task<IEnumerable<ResturantsOrders>> GetAsync()
        {
            _logger.LogInformation("You fetched all the restaurant orders.");
            return await _context.ResturantsOrders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ResturantsOrders> GetByIdAsync(int id)
        {
            _logger.LogInformation($"You fetched the restaurant order with the following ID: {id}");
            return await _context.ResturantsOrders.FirstOrDefaultAsync(order => order.Id == id);
        }

        [HttpPost]
        public async Task<ResturantsOrders> CreateAsync(string itemName, int quantity, int cost)
        {

            var requestedItem = await _farmermarketcontroller.GetbyNameAsync(itemName) ?? throw new Exception("The name you're ordering isn't found please make sure of it");
            if (quantity > requestedItem.Quantity)
            {
                quantity = requestedItem.Quantity;
                _farmermarketcontroller.UpdateAsync(requestedItem.Id, itemName, 0);
            }
            else {
                _farmermarketcontroller.UpdateAsync(requestedItem.Id, itemName, requestedItem.Quantity - quantity);
            }
            ResturantsOrders order = new ResturantsOrders(itemName, quantity, cost);
            _context.ResturantsOrders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        [HttpPut]
        public async Task<ResturantsOrders> UpdateAsync(int id, string newItemName, int newQuantity)
        {   
            ResturantsOrders order = await _context.ResturantsOrders.FirstOrDefaultAsync(o => o.Id == id);
            var requestedItem = await _farmermarketcontroller.GetbyNameAsync(newItemName) ?? throw new Exception("The name you're ordering isn't found please make sure of it");
            if (newQuantity > order.RequiredQuantity)
            {
                newQuantity = requestedItem.Quantity;
                _farmermarketcontroller.UpdateAsync(requestedItem.Id, newItemName, 0);
            }
            else { 
            _farmermarketcontroller.UpdateAsync(requestedItem.Id,newItemName, newQuantity);
            }
            order.UpdateResturantsOrder(newItemName, newQuantity);
            await _context.SaveChangesAsync();
            return order;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            ResturantsOrders order = await _context.ResturantsOrders.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            _context.ResturantsOrders.Remove(order);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
