using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UdemyTraining_ASP.NET_Core_REST_Web_API.Entities;
using UdemyTraining_ASP.NET_Core_REST_Web_API.Models;
using UdemyTraining_ASP.NET_Core_REST_Web_API.Services;

namespace UdemyTraining_ASP.NET_Core_REST_Web_API.Controllers
{
    [Route("api/restaurant/{restaurantId}/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute] int restaurantId)
        {
            _dishService.RemoveAll(restaurantId);

            return NoContent();
        }

        [HttpDelete("{dishId}")]
        public ActionResult DeletaById([FromRoute]int restaurantId, [FromRoute]int dishId)
        {
            _dishService.RemoveById(restaurantId, dishId);

            return NoContent();
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int restaurantId, [FromBody] CreateDishDto dto)
        {
            var newDishId = _dishService.Create(restaurantId, dto);

            return Created($"api/restaurant/{restaurantId}/dish/{newDishId}", null);
        }

        [HttpGet("{dishId}")]
        public ActionResult<DishDto> Get([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            DishDto dish = _dishService.GetById(restaurantId, dishId);
            return Ok(dish);
        }

        [HttpGet]
        public ActionResult<List<DishDto>> Get([FromRoute] int restaurantId)
        {
            var result = _dishService.GetAll(restaurantId);

            return Ok(result);
        }
    }
}
