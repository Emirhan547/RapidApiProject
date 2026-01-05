using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.SubscribeDtos;
using HotelRapidApi.EntityLayer.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class SubscribeManager(ISubscribeDal _subscribeDal, IMapper _mapper) : ISubscribeService
    {
        public async Task CreateAsync(CreateSubscribeDto create)
        {
            var subscriber = _mapper.Map<Subscribe>(create);
            await _subscribeDal.CreateAsync(subscriber);
        }

        public async Task DeleteAsync(int id)
        {
            var subscribe=await _subscribeDal.GetByIdAsync(id);
            await _subscribeDal.DeleteAsync(subscribe);
        }

        public async Task<ResultSubscribeDto> GetByIdAsync(int id)
        {
           var subscriber=await _subscribeDal.GetByIdAsync(id);
            return _mapper.Map<ResultSubscribeDto>(subscriber);
        }

        public async Task<List<ResultSubscribeDto>> GetListAsync()
        {
            var subscriber=await _subscribeDal.GetListAsync();
            return _mapper.Map<List<ResultSubscribeDto>>(subscriber);
        }

        public async Task UpdateAsync(UpdateSubscribeDto update)
        {
            var subscriber=_mapper.Map<Subscribe>(update);
            await _subscribeDal.UpdateAsync(subscriber);
        }
    }
}
