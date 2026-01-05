using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.SubscribeDtos;
using HotelRapidApi.EntityLayer.Concrete;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribesController(ISubscribeService _subscribeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> RoomList()
        {
            var values =await _subscribeService.GetListAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(CreateSubscribeDto subscribe)
        {
           await _subscribeService.CreateAsync(subscribe);
            return Ok(subscribe);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
          await  _subscribeService.DeleteAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutRoom(UpdateSubscribeDto subscribe)
        {
           await _subscribeService.UpdateAsync(subscribe);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetRoom(int Id)
        {
            var values = _subscribeService.GetByIdAsync(Id);
            return Ok(values);
        }
    }
}
