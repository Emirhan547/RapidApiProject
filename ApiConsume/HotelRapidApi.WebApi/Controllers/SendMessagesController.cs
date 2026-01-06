using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.SendMessageDtos;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessagesController(ISendMessageService _sendMessageService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var sendMessage=await _sendMessageService.GetListAsync();
            return Ok(sendMessage);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSendMessageAsync(int id)
        {
            var sendMessage=await _sendMessageService.GetByIdAsync(id);
            return Ok(sendMessage);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateSendMessageDto sendMessage)
        {
          await  _sendMessageService.CreateAsync(sendMessage);
           return Created();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateSendMessageDto sendMessage)
        {
           await _sendMessageService.UpdateAsync(sendMessage);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSendMessageAsync(int id)
        {
           await _sendMessageService.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet("GetSendMessageCount")]
        public async Task<IActionResult> GetSendMessageCountAsync()
        {
            await _sendMessageService.TGetSendMessageCount();
            return Ok();
        }
    }
}
