using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.ServiceDtos;
using HotelRapidApi.EntityLayer.Entities;
using Mapster;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class ServiceManager(IServicesDal _servicesDal) : IServiceService
    {
        public async Task CreateAsync(CreateServiceDto create)
        {
            var service=create.Adapt<Service>();
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
            return service.Adapt<ResultServiceDto>();
        }

        public async Task<List<ResultServiceDto>> GetListAsync()
        {
            var service=await _servicesDal.GetListAsync();
            return service.Adapt<List<ResultServiceDto>>();
        }

        public async Task UpdateAsync(UpdateServiceDto update)
        {
            var service = update.Adapt<Service>();
            await _servicesDal.UpdateAsync(service);
        }
    }
}
