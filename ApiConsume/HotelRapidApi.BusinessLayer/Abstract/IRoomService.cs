using HotelRapidApi.DtoLayer.DTOs.RoomDto;
using HotelRapidApi.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Abstract
{
    public interface IRoomService:IGenericService<ResultRoomDto,CreateRoomDto,UpdateRoomDto>
    {
        Task<int> RoomCount();
    }
}
