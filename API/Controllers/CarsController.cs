using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private static readonly string[] Makers = new[]
        {
            "Audi", "BMW", "Mercedes", "Ford", "Tesla", "Toyota", "...", "...", "...", "..."
        };

        private readonly ILogger<CarsController> _logger;

        public CarsController(ILogger<CarsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCars")]
        public IEnumerable<Car> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Car
            {
                Mileage = Random.Shared.Next(20000, 550000),
                Maker = Makers[Random.Shared.Next(Makers.Length)]
            })
            .ToArray();
        }
    }
}