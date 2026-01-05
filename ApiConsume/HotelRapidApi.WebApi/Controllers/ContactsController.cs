using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.ContactDtos;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IContactService _contactService) : ControllerBase
    {
       
        [HttpPost]
        public IActionResult AddContact(CreateContactDto contact)
        {
            contact.Date = Convert.ToDateTime(DateTime.Now.ToString());
            _contactService.CreateAsync(contact);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> InboxListContact()
        {
            var values =await _contactService.GetListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSendMessage(int id)
        {
            var values =await _contactService.GetByIdAsync(id);
            return Ok(values);
        }
        [HttpGet("GetContactCount")]
        public async Task<IActionResult> GetContactCountAsync()
        {
            await _contactService.TGetContactCount();
            return Ok();
        }

    }
}
