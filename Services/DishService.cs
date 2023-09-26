using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UdemyTraining_ASP.NET_Core_REST_Web_API.Entities;
using UdemyTraining_ASP.NET_Core_REST_Web_API.Exceptions;
using UdemyTraining_ASP.NET_Core_REST_Web_API.Models;

namespace UdemyTraining_ASP.NET_Core_REST_Web_API.Services
{
    public interface IDishService
    {
        int Create(int restaurantId, CreateDishDto dto);
        DishDto GetById(int restaurantId, int dishId);
        List<DishDto> GetAll(int restaurantId);
    }

    public class DishService : IDishService
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;

        public DishService(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(int restaurantId, CreateDishDto dto)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(c => c.Id == restaurantId);

            if (restaurant is null)
                throw new NotFoundExceptions("Restaurant not found.");

            var dishEntity = _mapper.Map<Dish>(dto);
            dishEntity.RestaurantId = restaurantId;

            _context.Dishes.Add(dishEntity);
            _context.SaveChanges();

            return dishEntity.Id;
        }

        public DishDto GetById(int restaurantId, int dishId)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(c => c.Id == restaurantId);
            if (restaurant is null)
                throw new NotFoundExceptions("Restaurant not found.");

            var dish = _context.Dishes.FirstOrDefault(d => d.Id == dishId);
            if (dish is null || dish.RestaurantId != restaurantId)
                throw new NotFoundExceptions("Dish not found.");

            var dishDto = _mapper.Map<DishDto>(dish);
            return dishDto;
        }

        public List<DishDto> GetAll(int restaurantId)
        {
            var restaurant = _context
                .Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefault(c => c.Id == restaurantId);
            if (restaurant is null)
                throw new NotFoundExceptions("Restaurant not found.");

            var dishDtos = _mapper.Map<List<DishDto>>(restaurant.Dishes);

            return dishDtos;
        }
    }
}
