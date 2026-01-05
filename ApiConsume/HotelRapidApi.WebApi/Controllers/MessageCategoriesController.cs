using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.MessageCategoryDtos;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoriesController(IMessageCategoryService _messageCategory) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMessageCategory()
        {
            var messageCategory =await _messageCategory.GetListAsync();
            return Ok(messageCategory);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessageCategory(CreateMessageCategoryDto messageCategory)
        {
           await _messageCategory.CreateAsync(messageCategory);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMessageCategory(UpdateMessageCategoryDto messageCategory)
        {
           await _messageCategory.UpdateAsync(messageCategory);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageCategoryAsync(int id)
        {
            await _messageCategory.DeleteAsync(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageCategoryByIdAsync(int id)
        {
            var category= await _messageCategory.GetByIdAsync(id);
            return Ok(category);
        }

    }
}
