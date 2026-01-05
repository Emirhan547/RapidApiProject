using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.ServiceDtos;
using HotelRapidApi.EntityLayer.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class ServiceManager(IServicesDal _servicesDal,IMapper _mapper) : IServiceService
    {
        public async Task CreateAsync(CreateServiceDto create)
        {
            var service=_mapper.Map<Service>(create);
            await _servicesDal.CreateAsync(service);
        }

        public async Task DeleteAsync(int id)
        {
            var service = await _servicesDal.GetByIdAsync(id);
           await _servicesDal.DeleteAsync(service);
        }

        public async Task<ResultServiceDto> GetByIdAsync(int id)
        {
            var service=await _servicesDal.GetByIdAsync(id);
            return _mapper.Map<ResultServiceDto>(service);
        }

        public async Task<List<ResultServiceDto>> GetListAsync()
        {
            var service=await _servicesDal.GetListAsync();
            return _mapper.Map<List<ResultServiceDto>>(service);
        }

        public async Task UpdateAsync(UpdateServiceDto update)
        {
            var service = _mapper.Map<Service>(update);
            await _servicesDal.UpdateAsync(service);
        }
    }
}
