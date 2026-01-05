using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.GuestDtos;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController(IGuestService _guestService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var guest=await _guestService.GetListAsync();
            return Ok(guest);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var guest =await _guestService.GetByIdAsync(id);
            return Ok(guest);
        }
        [HttpPost]
        public async Task<IActionResult> AddGuest(CreateGuestDto guest)
        {
           await _guestService.CreateAsync(guest);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGuestAsync(UpdateGuestDto guest)
        {
           await _guestService.UpdateAsync(guest);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuestAsync(int id)
        {
           await _guestService.DeleteAsync(id);
            return NoContent();
        }
    }
}
