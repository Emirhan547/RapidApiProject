using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController(IBookingService _bookingService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var booking=_bookingService.TGetList();
            return Ok(booking);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var books=_bookingService.TGetById(id);
            return Ok(books);
        }
        [HttpPost]
        public IActionResult Create(Booking booking )
        {
            _bookingService.TInsert(booking);
            return Created();
        }
        [HttpPut]
        public IActionResult Update(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var booking = _bookingService.TGetById(id);
            _bookingService.TDelete(booking);
            return Ok();
        }
    }
}
