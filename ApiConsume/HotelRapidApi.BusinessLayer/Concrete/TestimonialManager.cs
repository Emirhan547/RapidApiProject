using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.TestimonialDto;
using HotelRapidApi.EntityLayer.Entities;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.BusinessLayer.Concrete
{
    public class TestimonialManager(ITestimonialDal _testimonialDal) : ITestimonialService
    {
        public async Task CreateAsync(CreateTestimonialDto create)
        {
            var testimonials = create.Adapt<Testimonial>();
            await _testimonialDal.CreateAsync(testimonials);
        }

        public async Task DeleteAsync(int id)
        {
            var testimonial = await _testimonialDal.GetByIdAsync(id);
            await _testimonialDal.DeleteAsync(testimonial);
        }

        public async Task<ResultTestimonialDto> GetByIdAsync(int id)
        {
            var testimonials=await _testimonialDal.GetByIdAsync(id);
            return testimonials.Adapt<ResultTestimonialDto>();
        }

        public async Task<List<ResultTestimonialDto>> GetListAsync()
        {
            var testimonials = await _testimonialDal.GetListAsync();
            return testimonials.Adapt<List<ResultTestimonialDto>>();
        }

        public async Task UpdateAsync(UpdateTestimonialDto update)
        {
           var testimonials=update.Adapt<Testimonial>();
            await _testimonialDal.UpdateAsync(testimonials);
        }
    }
}
