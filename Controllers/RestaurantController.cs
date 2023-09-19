using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UdemyTraining_ASP.NET_Core_REST_Web_API.Entities;

namespace UdemyTraining_ASP.NET_Core_REST_Web_API.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantController(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetAll()
        {
            var restaurants = _dbContext.Restaurants.ToList();
            return Ok(restaurants);
        }
        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get([FromRoute] int id)
        {
            var restaurant = _dbContext.Restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant is null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }
    }
}
