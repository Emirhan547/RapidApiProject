using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.RoomDto;
using HotelRapidApi.EntityLayer.Concrete;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class RoomManager(IRoomDal _roomDal, IMapper _mapper) : IRoomService
    {
        public async Task CreateAsync(CreateRoomDto create)
        {
            var room=_mapper.Map<Room>(create);
            await _roomDal.CreateAsync(room);
        }

        public async Task DeleteAsync(int id)
        {
            var room = await _roomDal.GetByIdAsync(id);
            await _roomDal.DeleteAsync(room);
        }

        public async Task<ResultRoomDto> GetByIdAsync(int id)
        {
            var room=await _roomDal.GetByIdAsync(id);
            return _mapper.Map<ResultRoomDto>(room);
        }

        public async Task<List<ResultRoomDto>> GetListAsync()
        {
            var room = await _roomDal.GetListAsync();
            return _mapper.Map<List<ResultRoomDto>>(room);
        }

        public async Task<int> RoomCount()
        {
          return  await _roomDal.RoomCount();
        }

        public async Task UpdateAsync(UpdateRoomDto update)
        {
           var rooms=_mapper.Map<Room>(update);
            await _roomDal.UpdateAsync(rooms);
        }
    }
}
