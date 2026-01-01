using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationsController(IWorkLocationService _workLocation) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetWorkLocation()
        {
            var workLocations = _workLocation.TGetList();
            return Ok(workLocations);
        }
        [HttpGet("{id}")]
        public IActionResult GetWorkLocation(int id)
        {
            var workLocations=_workLocation.TGetById(id);
            return Ok(workLocations);
        }
        [HttpPost]
        public IActionResult CreateWorkLocation(WorkLocation workLocation)
        {
            _workLocation.TInsert(workLocation);
            return Created();
        }
        [HttpPut]
        public IActionResult UpdateWorkLocation(WorkLocation workLocation)
        {
            _workLocation.TUpdate(workLocation);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteWorkLocation(int id)
        {
            var workLocation=_workLocation.TGetById(id);
            _workLocation.TDelete(workLocation);
            return Ok();
        }

    }
}
