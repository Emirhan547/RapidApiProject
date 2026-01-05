using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.ServiceDtos;
using HotelRapidApi.EntityLayer.Concrete;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController(IServiceService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var values =await _service.GetListAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddService(CreateServiceDto service)
        {
           await _service.CreateAsync(service);
            return Ok(service);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
           await _service.DeleteAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutService(UpdateServiceDto service)
        {
          await  _service.UpdateAsync(service);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int Id)
        {
            var values =await _service.GetByIdAsync(Id);
            return Ok(values);
        }
    }
}
