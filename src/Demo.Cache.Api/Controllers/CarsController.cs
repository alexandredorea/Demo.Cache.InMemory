using Demo.Cache.Api.Stores;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Cache.Api.Controllers
{
    [ApiController]
    [Route("cars")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService store)
        {
            _carService = store;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_carService.List());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_carService.Get(id));
        }
    }
}