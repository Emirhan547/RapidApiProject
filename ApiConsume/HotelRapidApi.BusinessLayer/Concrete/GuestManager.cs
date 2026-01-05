using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.BookingDtos;
using HotelRapidApi.DtoLayer.DTOs.GuestDtos;
using HotelRapidApi.EntityLayer.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class GuestManager(IGuestDal _guestDal,IMapper _mapper) : IGuestService
    {
        public async Task CreateAsync(CreateGuestDto create)
        {
           var guest=_mapper.Map<Guest>(create);
            await _guestDal.CreateAsync(guest);
        }

        public async Task DeleteAsync(int id)
        {
            await _guestDal.DeleteAsync(id);
        }

        public async Task<ResultGuestDto> GetByIdAsync(int id)
        {
           var guest=await _guestDal.GetByIdAsync(id);
            return _mapper.Map<ResultGuestDto>(guest);
        }

        public async Task<List<ResultGuestDto>> GetListAsync()
        {
           var guest=await _guestDal.GetListAsync();
            return _mapper.Map<List<ResultGuestDto>>(guest);
        }

        public async Task UpdateAsync(UpdateGuestDto update)
        {
            var guest=_mapper.Map<Guest>(update);
             await _guestDal.UpdateAsync(guest);
        }
    }
}
