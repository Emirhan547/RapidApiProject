using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.StaffDtos;
using HotelRapidApi.EntityLayer.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class StaffManager(IStaffDal _staffDal, IMapper _mapper) : IStaffService
    {
        public async Task CreateAsync(CreateStaffDto create)
        {
            var staff=_mapper.Map<Staff>(create);
            await _staffDal.CreateAsync(staff);
        }

        public async Task DeleteAsync(int id)
        {
            var staff = await _staffDal.GetByIdAsync(id);
            await _staffDal.DeleteAsync(staff);
        }

        public async Task<ResultStaffDto> GetByIdAsync(int id)
        {
            var staff = await _staffDal.GetByIdAsync(id);
            return _mapper.Map<ResultStaffDto>(staff);
        }

        public async Task<List<ResultStaffDto>> GetListAsync()
        {
            var staff=await _staffDal.GetListAsync();
            return _mapper.Map<List<ResultStaffDto>>(staff);
        }

        public async Task<int> TGetStaffCount()
        {
            return await _staffDal.GetStaffCount();
        }

        public async Task<List<ResultStaffDto>> TLast4Staff()
        {
            var staff=await _staffDal.Last4Staff();
            return _mapper.Map<List<ResultStaffDto>>(staff);
        }

        public async Task UpdateAsync(UpdateStaffDto update)
        {
            var staff=_mapper.Map<Staff>(update);
            await _staffDal.UpdateAsync(staff);
        }
    }
}
