using AliAwdiAnotherOne.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AliAwdiAnotherOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerMarketController : ControllerBase
    {
        private readonly ILogger<FarmerMarketController> _logger;
        private readonly FarmersMarketDbContext _context;

        public FarmerMarketController(ILogger<FarmerMarketController> logger, FarmersMarketDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<FarmerMarket>> GetAsync()
        {
            _logger.LogInformation("You fetched all the goods in your store");
            return await _context.FarmerMarkets.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<FarmerMarket> GetByIdAsync(int id)
        {
            _logger.LogInformation($"You fetched the vegetables/fruits with the following ID: {id}");
            return await _context.FarmerMarkets.FirstOrDefaultAsync(farmermarket => farmermarket.Id == id);
        }
        [HttpGet("name")]
        public async Task<FarmerMarket> GetbyNameAsync (string name)
        {
            _logger.LogInformation($"You fetched all the fruits and vegetables with this name: {name}");
            return await _context.FarmerMarkets.FirstOrDefaultAsync(farmermarket => farmermarket.Name == name);
        }

        [HttpPost]
        public async Task<FarmerMarket> CreateAsync(string name, int quantity)
        {
            FarmerMarket farmerMarket = new(name, quantity);
            _context.FarmerMarkets.Add(farmerMarket);
            await _context.SaveChangesAsync();
            return farmerMarket;
        }

        [HttpPut]
        public async Task<FarmerMarket> UpdateAsync(int id, string newname, int newquantity)
        {
            FarmerMarket farmerMarket = await _context.FarmerMarkets.FirstOrDefaultAsync(fm => fm.Id == id);
            farmerMarket.UpdateFarmerMarket(newname, newquantity);
            await _context.SaveChangesAsync();
            return farmerMarket;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            FarmerMarket farmerMarket = await _context.FarmerMarkets.FirstOrDefaultAsync(fm => fm.Id == id);
            if (farmerMarket == null)
            {
                return NotFound();
            }

            _context.FarmerMarkets.Remove(farmerMarket);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
    
}

