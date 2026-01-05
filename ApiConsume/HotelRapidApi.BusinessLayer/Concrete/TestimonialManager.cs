using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.TestimonialDto;
using HotelRapidApi.EntityLayer.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class TestimonialManager(ITestimonialDal _testimonialDal, IMapper _mapper) : ITestimonialService
    {
        public async Task CreateAsync(CreateTestimonialDto create)
        {
            var testimonials = _mapper.Map<Testimonial>(create);
            await _testimonialDal.CreateAsync(testimonials);
        }

        public async Task DeleteAsync(int id)
        {
            await _testimonialDal.DeleteAsync(id);
        }

        public async Task<ResultTestimonialDto> GetByIdAsync(int id)
        {
            var testimonials=await _testimonialDal.GetByIdAsync(id);
            return _mapper.Map<ResultTestimonialDto>(testimonials);
        }

        public async Task<List<ResultTestimonialDto>> GetListAsync()
        {
            var testimonials = await _testimonialDal.GetListAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(testimonials);
        }

        public async Task UpdateAsync(UpdateTestimonialDto update)
        {
           var testimonials=_mapper.Map<Testimonial>(update);
            await _testimonialDal.UpdateAsync(testimonials);
        }
    }
}
