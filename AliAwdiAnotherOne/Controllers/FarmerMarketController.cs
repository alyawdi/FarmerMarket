﻿using AliAwdiAnotherOne.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AliAwdiAnotherOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerMarketController : ControllerBase
    {
        private readonly ILogger<FarmerMarketController> _logger;
        private readonly AppDbContext _context;

        public FarmerMarketController(ILogger<FarmerMarketController> logger, AppDbContext context)
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
            return await _context.FarmerMarkets.FirstOrDefaultAsync(fm => fm.Id == id) ?? throw new Exception("Market not found.");
        }
        [HttpGet("name")]
        public async Task<FarmerMarket> GetByNameAsync(string name)
        {
            _logger.LogInformation($"You fetched all the fruits and vegetables with this name: {name}");
            return await _context.FarmerMarkets.FirstOrDefaultAsync(fm => fm.Name == name) ?? throw new Exception("Market not found.");
        }

        [HttpPost]
        public async Task<FarmerMarket> CreateAsync(string name, int quantity)
        {
            var farmerMarket = new FarmerMarket(name, quantity);
            _context.FarmerMarkets.Add(farmerMarket);
            await _context.SaveChangesAsync();
            return farmerMarket;
        }

        [HttpPut]
        public async Task<FarmerMarket> UpdateAsync(int id, string newName, int newQuantity)
        {
            var farmerMarket = await _context.FarmerMarkets.FirstOrDefaultAsync(fm => fm.Id == id) ?? throw new Exception("Market not found.");
            farmerMarket.UpdateFarmerMarket(newName, newQuantity);
            await _context.SaveChangesAsync();
            return farmerMarket;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var farmerMarket = await _context.FarmerMarkets.FirstOrDefaultAsync(fm => fm.Id == id);
            if (farmerMarket is null)
                return NotFound();

            _context.FarmerMarkets.Remove(farmerMarket);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

