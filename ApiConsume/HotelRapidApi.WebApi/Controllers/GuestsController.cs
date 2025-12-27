using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController(IGuestService _guestService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var guest= _guestService.TGetList();
            return Ok(guest);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var guest = _guestService.TGetById(id);
            return Ok(guest);
        }
        [HttpPost]
        public IActionResult AddGuest(Guest guest)
        {
            _guestService.TInsert(guest);
            return Created();
        }
        [HttpPut]
        public IActionResult UpdateGuest(Guest guest)
        {
            _guestService.TUpdate(guest);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGuest(int id)
        {
            var guest = _guestService.TGetById(id);
            _guestService.TDelete(guest);
            return NoContent();
        }
    }
}
