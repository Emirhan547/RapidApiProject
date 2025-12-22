using AutoMapper;
using HotelRapidApi.EntityLayer.Entities;
using HotelRapidApi.WebUI.DTOs.LoginDtos;
using HotelRapidApi.WebUI.DTOs.RegisterDtos;
using HotelRapidApi.WebUI.DTOs.ServiceDtos;

namespace HotelRapidApi.WebUI.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();

            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
            CreateMap<LoginUserDto, AppUser>().ReverseMap();

        }
    }
}
