using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.WorkLocationDtos;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationsController(IWorkLocationService _workLocation) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetWorkLocation()
        {
            var workLocations =await _workLocation.GetListAsync();
            return Ok(workLocations);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkLocationAsync(int id)
        {
            var workLocations= await _workLocation.GetByIdAsync(id);
            return Ok(workLocations);
        }
        [HttpPost]
        public IActionResult CreateWorkLocation(CreateWorkLocationDto workLocation)
        {
            _workLocation.CreateAsync(workLocation);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWorkLocation(UpdateWorkLocationDto workLocation)
        {
           await _workLocation.UpdateAsync(workLocation);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkLocation(int id)
        {
           await _workLocation.DeleteAsync(id);
            return Ok();
        }

    }
}
