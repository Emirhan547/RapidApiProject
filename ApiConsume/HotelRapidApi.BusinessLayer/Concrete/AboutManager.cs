using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.AboutDtos;
using HotelRapidApi.EntityLayer.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class AboutManager(IAboutDal _aboutDal,IMapper _mapper) : IAboutService
    {
        public async Task CreateAsync(CreateAboutDto create)
        {
            var about=_mapper.Map<About>(create);
            await _aboutDal.CreateAsync(about);
        }

        public async Task DeleteAsync(int id)
        {
            var abouts=await _aboutDal.GetByIdAsync(id);
            await _aboutDal.DeleteAsync(abouts);
        }

        public async Task<ResultAboutDto> GetByIdAsync(int id)
        {
            var about= await _aboutDal.GetByIdAsync(id);
            return _mapper.Map<ResultAboutDto>(about);

        }

        public async Task<List<ResultAboutDto>> GetListAsync()
        {
           var abouts=await _aboutDal.GetListAsync();
            return _mapper.Map<List<ResultAboutDto>>(abouts);
        }

        public async Task UpdateAsync(UpdateAboutDto update)
        {
            var abouts= _mapper.Map<About>(update);
            await _aboutDal.UpdateAsync(abouts);
        }
    }
}
