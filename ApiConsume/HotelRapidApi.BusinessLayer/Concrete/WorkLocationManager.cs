using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.WorkLocationDtos;
using HotelRapidApi.EntityLayer.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class WorkLocationManager(IWorkLocationDal _workLocation,IMapper _mapper) : IWorkLocationService
    {
        public async Task CreateAsync(CreateWorkLocationDto create)
        {
            var workLocation = _mapper.Map<WorkLocation>(create);
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
            return _mapper.Map<ResultWorkLocationDto>(workLocations);
        }

        public async Task<List<ResultWorkLocationDto>> GetListAsync()
        {
            var workLocation=await _workLocation.GetListAsync();
            return _mapper.Map<List<ResultWorkLocationDto>>(workLocation);
        }

        public async Task UpdateAsync(UpdateWorkLocationDto update)
        {
            var workLocations=_mapper.Map<WorkLocation>(update);
            await _workLocation.UpdateAsync(workLocations);
        }
    }
}
