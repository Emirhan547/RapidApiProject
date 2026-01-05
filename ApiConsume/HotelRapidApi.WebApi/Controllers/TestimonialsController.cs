using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.TestimonialDto;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(ITestimonialService _testimonialService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values =await _testimonialService.GetListAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(CreateTestimonialDto testimonial)
        {
           await _testimonialService.CreateAsync(testimonial);
            return Ok(testimonial);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
          await _testimonialService.DeleteAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutTestimonial(UpdateTestimonialDto testimonial)
        {
          await  _testimonialService.UpdateAsync(testimonial);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int Id)
        {
            var values =await _testimonialService.GetByIdAsync(Id);
            return Ok(values);
        }
    }
}
