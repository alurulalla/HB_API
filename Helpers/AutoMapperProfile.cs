using AutoMapper;
using HummingBoxApp.API.Dtos;
using HummingBoxApp.API.Models;

namespace HummingBoxApp.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<OrderForCreationDto, Order>().ReverseMap();
            CreateMap<ItemForCreationDto, OrderDetail>();
            CreateMap<HistoryListDto, Order>();
            CreateMap<HistoryListDto, OrderDetail>();
        }
    }
}