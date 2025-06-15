using System;
using AutoMapper;
using Restaurants.Entities;

namespace Restaurants.Application.Dishes.Dtos;

public class DishesProfile : Profile
{

    public DishesProfile()
    {
        CreateMap<Dish, DishDto>();
    }

}
