using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController(IStaffService _staffService) : ControllerBase
    {
        [HttpGet]
        public IActionResult StaffList()
        {
            var values = _staffService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            _staffService.TInsert(staff);
            return Ok(staff);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int Id)
        {
            var values=_staffService.TGetById(Id);
            _staffService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult PutStaff(Staff staff)
        {
            _staffService.TUpdate(staff);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetStaff(int Id)
        { 
            var values= _staffService.TGetById(Id);
            return Ok(values);  
        }
        [HttpGet("Last4Staff")]
        public IActionResult Last4Staff()
        {
            var values=_staffService.TLast4Staff();
            return Ok(values);
        }
    }
}
