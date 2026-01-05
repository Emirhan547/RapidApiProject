using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.AboutDtos;
using HotelRapidApi.EntityLayer.Concrete;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IAboutService _aboutService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ListAbout()
        {
            var values =await _aboutService.GetListAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto about)
        {
           await _aboutService.CreateAsync(about);
            return Ok(about);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
           await _aboutService.DeleteAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto about)
        {
           await _aboutService.UpdateAsync(about);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAbout(int Id)
        {
            var values =await _aboutService.GetByIdAsync(Id);
            return Ok(values);
        }
    }
}
