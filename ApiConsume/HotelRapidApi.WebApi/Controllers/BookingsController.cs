using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.BookingDtos;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController(IBookingService _bookingService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ListBooking()
        {
            var values =await _bookingService.GetListAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto booking)
        {
           await _bookingService.CreateAsync(booking);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
           await _bookingService.DeleteAsync(id);
            return Ok();
        }
        [HttpPut("UpdateBooking")]
        public async Task<IActionResult> UpdateBookingAsync(UpdateBookingDto booking)
        {
           await _bookingService.UpdateAsync(booking);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            var values =await _bookingService.GetByIdAsync(id);
            return Ok(values);
        }

        [HttpGet("Last6Booking")]
        public async Task<IActionResult> Last6Booking()
        {
            var values =await _bookingService.TLast6Bookings();
            return Ok(values);
        }

        [HttpGet("BookingAproved")]
        public async Task<IActionResult> BookingAproved(int id)
        {
            await _bookingService.TBookingStatusChangeApproved3(id);
            return Ok();
        }

        [HttpGet("BookingCancel")]
        public async Task <IActionResult> BookingCancel(int id)
        {
            await _bookingService.TBookingStatusChangeCancel(id);
            return Ok();
        }
        [HttpGet("BookingWait")]
        public async Task<IActionResult> BookingWait(int id)
        {
           await _bookingService.TBookingStatusChangeWait(id);
            return Ok();
        }

    }
}
