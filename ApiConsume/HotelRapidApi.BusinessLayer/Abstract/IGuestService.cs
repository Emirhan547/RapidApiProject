

using HotelRapidApi.DtoLayer.DTOs.GuestDtos;

namespace HotelRapidApi.BusinessLayer.Abstract
{
    public interface IGuestService: IGenericService<ResultGuestDto,CreateGuestDto,UpdateGuestDto>
    {
    }
}
