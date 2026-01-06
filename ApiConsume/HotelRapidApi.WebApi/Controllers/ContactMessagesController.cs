using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.ContactMessageDtos;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMessagesController(IContactMessageService _contactMessageService) : ControllerBase
    {
       
        [HttpPost]
        public async Task<IActionResult> AddContact(CreateContactMessageDto contact)
        {
            contact.Date = Convert.ToDateTime(DateTime.Now.ToString());
            await _contactMessageService.CreateAsync(contact);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> InboxListContact()
        {
            var values = await _contactMessageService.GetListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSendMessage(int id)
        {
            var values = await _contactMessageService.GetByIdAsync(id);
            return Ok(values);
        }
        [HttpGet("GetContactCount")]
        public async Task<IActionResult> GetContactCountAsync()
        {
            var count = await _contactMessageService.TGetContactCount();
            return Ok(count);
        }

    }
}
