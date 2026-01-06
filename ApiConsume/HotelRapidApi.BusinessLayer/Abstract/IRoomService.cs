



using HotelRapidApi.DtoLayer.DTOs.RoomDtos;

namespace HotelRapidApi.BusinessLayer.Abstract
{
    public interface IRoomService:IGenericService<ResultRoomDto,CreateRoomDto,UpdateRoomDto>
    {
        Task<int> RoomCount();
    }
}
