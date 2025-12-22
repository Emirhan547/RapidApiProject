using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.EntityLayer.Concrete;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribesController(ISubscribeService _subscribeService) : ControllerBase
    {
        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _subscribeService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRoom(Subscribe subscribe)
        {
            _subscribeService.TInsert(subscribe);
            return Ok(subscribe);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int Id)
        {
            var values = _subscribeService.TGetById(Id);
            _subscribeService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult PutRoom(Subscribe subscribe)
        {
            _subscribeService.TUpdate(subscribe);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetRoom(int Id)
        {
            var values = _subscribeService.TGetById(Id);
            return Ok(values);
        }
    }
}
