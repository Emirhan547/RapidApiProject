using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.EntityLayer.Concrete;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController(IServiceService _service) : ControllerBase
    {
        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _service.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _service.TInsert(service);
            return Ok(service);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteService(int Id)
        {
            var values = _service.TGetById(Id);
            _service.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult PutService(Service service)
        {
            _service.TUpdate(service);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetService(int Id)
        {
            var values = _service.TGetById(Id);
            return Ok(values);
        }
    }
}
