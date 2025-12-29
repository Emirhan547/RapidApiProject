using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessagesController(ISendMessageService _sendMessageService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            var sendMessage=_sendMessageService.TGetList();
            return Ok(sendMessage);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var sendMessage=_sendMessageService.TGetById(id);
            return Ok(sendMessage);
        }
        [HttpPost]
        public IActionResult CreateMessage(SendMessage sendMessage)
        {
            _sendMessageService.TInsert(sendMessage);
            return Created();
        }
        [HttpPut]
        public IActionResult UpdateMessage(SendMessage sendMessage)
        {
            _sendMessageService.TUpdate(sendMessage);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSendMessage(int id)
        {
            var message=_sendMessageService.TGetById(id);
            _sendMessageService.TDelete(message);
            return NoContent();
        }
    }
}
