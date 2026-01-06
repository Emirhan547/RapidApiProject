using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.RoomDto;
using HotelRapidApi.EntityLayer.Concrete;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController(IRoomService _roomService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> RoomList()
        {
            var values =await _roomService.GetListAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom([FromBody] CreateRoomDto room)
        {
           await _roomService.CreateAsync(room);
            return Ok(room);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
          await  _roomService.DeleteAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutRoom(UpdateRoomDto room)
        {
          await  _roomService.UpdateAsync(room);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int Id)
        {
            var values = await _roomService.GetByIdAsync(Id);
            return Ok(values);
        }
    }
}
