using Microsoft.AspNetCore.Mvc;
using AliAwdiAnotherOne.Models;
using System.Xml.Linq;

namespace AliAwdiAnotherOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerMarketControll : ControllerBase

    {
        private readonly ILogger<FarmerMarketControll> _logger;

        public FarmerMarketControll(ILogger<FarmerMarketControll> logger)
        {
            _logger = logger;
        }
        private static readonly List<FarmerMarket> farmermarket = new();

        [HttpGet]
        public IEnumerable<FarmerMarket> Get()
        {
            _logger.LogInformation("You fetched all the goods in your store");
            return farmermarket;
        }

        [HttpGet("id")]
        public FarmerMarket GetById(int id)
        {
            _logger.LogInformation($"you fetch the vegetables/fruits with the following {id}");
            return farmermarket.First(farmermarket => farmermarket.Id == id);
        }

        [HttpPost]
        public FarmerMarket Create(string name, int quantity)
        {
            FarmerMarket farmerMarket = new(name, quantity);
            farmermarket.Add(farmerMarket);
            return farmerMarket;
        }

        [HttpPut]
        public FarmerMarket Update(int searchingid, string name, int quantity)
        {
            var farmerMarket = farmermarket.Where(farmerMarket => farmerMarket.Id == searchingid).FirstOrDefault();

            farmerMarket.UpdateFramework(name, quantity);
            return farmerMarket;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            farmermarket.RemoveAll(farmermaket => farmermaket.Id == id);


        }
        [HttpPatch]
        public FarmerMarket Patch(int id, int quantity)
        {
            var farmerMarket = farmermarket.Where(farmerMarket => farmerMarket.Id == id).FirstOrDefault();

            farmerMarket.UpdateFramework(farmerMarket.Name, quantity);
            return farmerMarket;

        }






    }
}
