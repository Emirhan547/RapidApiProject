using AutoMapper;
using HotelRapidApi.DtoLayer.DTOs.RoomDto;
using HotelRapidApi.EntityLayer.Concrete;

namespace HotelRapidApi.WebApi.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
                CreateMap<Room,RoomAddDto>().ReverseMap();
                CreateMap<Room,UpdateRoomDto>().ReverseMap();
        }
    }
}
