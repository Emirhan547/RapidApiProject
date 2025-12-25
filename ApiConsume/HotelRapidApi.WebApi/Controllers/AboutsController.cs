using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.EntityLayer.Concrete;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IAboutService _aboutService) : ControllerBase
    {
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddAbout(About about)
        {
            _aboutService.TInsert(about);
            return Ok(about);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int Id)
        {
            var values = _aboutService.TGetById(Id);
            _aboutService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult PutAbout(About about)
        {
            _aboutService.TUpdate(about);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int Id)
        {
            var values = _aboutService.TGetById(Id);
            return Ok(values);
        }
    }
}
