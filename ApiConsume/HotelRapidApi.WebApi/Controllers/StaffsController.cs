using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.StaffDtos;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController(IStaffService _staffService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> StaffList()
        {
            var values =await _staffService.GetListAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(CreateStaffDto staff)
        {
           await _staffService.CreateAsync(staff);
            return Ok(staff);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
          await  _staffService.DeleteAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutStaff(UpdateStaffDto staff)
        {
           await _staffService.UpdateAsync(staff);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaff(int Id)
        { 
            var values=await _staffService.GetByIdAsync(Id);
            return Ok(values);  
        }
        [HttpGet("Last4Staff")]
        public async Task<IActionResult> Last4StaffAsync()
        {
            var values=await _staffService.TLast4Staff();
            return Ok(values);
        }
    }
}
