using AliAwdiAnotherOne.Models;
using Microsoft.AspNetCore.Mvc;

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
            /*the list was removed and subistute by a database inside my memory*/
        [HttpGet]
        public IEnumerable<FarmerMarket> Get()
        {
            _logger.LogInformation("You fetched all the goods in your store");
            return _context.FarmerMarkets.AsQueryable().ToList();
        }

        [HttpGet("{id}")]
        public FarmerMarket GetById(int id)
        {
            _logger.LogInformation($"You fetched the vegetables/fruits with the following ID: {id}");
            return _context.FarmerMarkets.FirstOrDefault(farmermarket => farmermarket.Id == id);
        }

        [HttpPost]
        public FarmerMarket Create(string name, int quantity)
        {
            FarmerMarket farmerMarket = new(name, quantity);
            _context.FarmerMarkets.Add(farmerMarket);
            _context.SaveChanges();
            return farmerMarket;
        }

        [HttpPut]
        public FarmerMarket Update(int id, string newname, int newquantity )
        {
            FarmerMarket farmerMarket = _context.FarmerMarkets.FirstOrDefault(fm => fm.Id == id);
            farmerMarket.UpdateFarmerMarket(newname, newquantity);
            _context.SaveChangesAsync();
           return farmerMarket;

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            FarmerMarket farmerMarket = _context.FarmerMarkets.FirstOrDefault(fm => fm.Id == id);
            if (farmerMarket == null)
            {
                return NotFound();
            }

             _context.FarmerMarkets.Remove(farmerMarket);
              _context.SaveChanges();
            return Ok();
        }
    }
}
