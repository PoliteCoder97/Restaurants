using AutoMapper;
using DefaultNamespace;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Entities;

namespace Restaurants.Application.Restaurants.Dtos;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<UpdateRestaurantCommand, Restaurant>()
            .ForMember(d => d.Address, opt => opt.MapFrom(s => new Address
            {
                City = s.City,
                Street = s.Street,
                PostalCode = s.PostalCode
            }));

        CreateMap<CreateRestaurantCommand, Restaurant>()
            .ForMember(d => d.Address, opt => opt.MapFrom(s => new Address
            {
                City = s.City,
                Street = s.Street,
                PostalCode = s.PostalCode
            }));

        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(d => d.City,
                opt => opt.MapFrom(s => s.Address == null ? null : s.Address.City))
            .ForMember(d => d.PostalCode,
                opt => opt.MapFrom(s => s.Address == null ? null : s.Address.PostalCode))
            .ForMember(d => d.Street,
                opt => opt.MapFrom(s => s.Address == null ? null : s.Address.Street))
            .ForMember(d => d.Dishes, opt => opt.MapFrom(s => s.Dishes));
    }
}