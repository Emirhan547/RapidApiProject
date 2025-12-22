using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.EntityLayer.Concrete;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController(IRoomService _roomService) : ControllerBase
    {
        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            _roomService.TInsert(room);
            return Ok(room);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int Id)
        {
            var values = _roomService.TGetById(Id);
            _roomService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult PutRoom(Room room)
        {
            _roomService.TUpdate(room);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetRoom(int Id)
        {
            var values = _roomService.TGetById(Id);
            return Ok(values);
        }
    }
}
