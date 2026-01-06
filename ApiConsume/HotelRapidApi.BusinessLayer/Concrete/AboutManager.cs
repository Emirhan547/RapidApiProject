using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.AboutDtos;
using HotelRapidApi.EntityLayer.Entities;
using Mapster;


namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class AboutManager(IAboutDal _aboutDal) : IAboutService
    {
        public async Task CreateAsync(CreateAboutDto create)
        {
            var about=create.Adapt<About>();
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
           return about.Adapt<ResultAboutDto>();


        }

        public async Task<List<ResultAboutDto>> GetListAsync()
        {
           var abouts=await _aboutDal.GetListAsync();
            return abouts.Adapt <List<ResultAboutDto>>();
        }

        public async Task UpdateAsync(UpdateAboutDto update)
        {
            var abouts= update.Adapt<About>();
            await _aboutDal.UpdateAsync(abouts);
        }
    }
}
