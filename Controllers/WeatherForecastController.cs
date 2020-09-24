using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeShop.Enties;
using CoffeShop.EntitiesFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoffeShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly CoffeShopDbContext _context;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, CoffeShopDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        

        [HttpGet]
        public List<OrderEntry> Test()
        {

            
            return _context.OrderEntry.Select(p => p).GroupBy(g => g.CreatedBy).Select(s => s.First()).ToList() ;
        }
    }
}
