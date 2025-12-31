using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoriesController(IMessageCategoryService _messageCategory) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessageCategory()
        {
            var messageCategory = _messageCategory.TGetList();
            return Ok(messageCategory);
        }
        [HttpPost]
        public IActionResult CreateMessageCategory(MessageCategory messageCategory)
        {
            _messageCategory.TInsert(messageCategory);
            return Created();
        }
        [HttpPut]
        public IActionResult UpdateMessageCategory(MessageCategory messageCategory)
        {
            _messageCategory.TUpdate(messageCategory);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessageCategory(int id)
        {
            var category=_messageCategory.TGetById(id);
            _messageCategory.TDelete(category);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetMessageCategoryById(int id)
        {
            var category=_messageCategory.TGetById(id);
            return Ok(category);
        }

    }
}
