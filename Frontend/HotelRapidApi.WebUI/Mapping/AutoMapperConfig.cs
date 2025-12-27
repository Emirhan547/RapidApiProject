using AutoMapper;
using HotelRapidApi.EntityLayer.Entities;
using HotelRapidApi.WebUI.DTOs.AboutDtos;
using HotelRapidApi.WebUI.DTOs.BookingDtos;
using HotelRapidApi.WebUI.DTOs.GuestDtos;
using HotelRapidApi.WebUI.DTOs.LoginDtos;
using HotelRapidApi.WebUI.DTOs.RegisterDtos;
using HotelRapidApi.WebUI.DTOs.ServiceDtos;
using HotelRapidApi.WebUI.DTOs.StaffDtos;
using HotelRapidApi.WebUI.DTOs.SubscribeDtos;
using HotelRapidApi.WebUI.DTOs.TestimonialDtos;

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

            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<ResultStaffDto, Staff>().ReverseMap();
            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<CreateBookingDto, Booking>().ReverseMap();
            CreateMap<ApprovedReservationDto, Booking>().ReverseMap();
            CreateMap<CreateGuestDto, Guest>().ReverseMap();
            CreateMap<UpdateGuestDto, Guest>().ReverseMap();
        }
    }
}

