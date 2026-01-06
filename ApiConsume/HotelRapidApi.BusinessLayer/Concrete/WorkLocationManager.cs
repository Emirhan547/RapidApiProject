using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.WorkLocationDtos;
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
    public class WorkLocationManager(IWorkLocationDal _workLocation) : IWorkLocationService
    {
        public async Task CreateAsync(CreateWorkLocationDto create)
        {
            var workLocation = create.Adapt<WorkLocation>();
            await _workLocation.CreateAsync(workLocation);
        }

        public async Task DeleteAsync(int id)
        {
            var workLocation = await _workLocation.GetByIdAsync(id);
            await _workLocation.DeleteAsync(workLocation);
        }

        public async Task<ResultWorkLocationDto> GetByIdAsync(int id)
        {
            var workLocations=await _workLocation.GetByIdAsync(id);
            return workLocations.Adapt<ResultWorkLocationDto>();
        }

        public async Task<List<ResultWorkLocationDto>> GetListAsync()
        {
            var workLocation=await _workLocation.GetListAsync();
            return workLocation.Adapt<List<ResultWorkLocationDto>>();
        }

        public async Task UpdateAsync(UpdateWorkLocationDto update)
        {
            var workLocations=update.Adapt<WorkLocation>();
            await _workLocation.UpdateAsync(workLocations);
        }
    }
}
