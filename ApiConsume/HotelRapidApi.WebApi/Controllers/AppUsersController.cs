using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController(IAppUserService _appUserService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var values = await _appUserService.GetListAsync();
            return Ok(values);
        }
        [HttpGet("WithWorkLocation")]
        public async Task<IActionResult> GetUserListWithLocation()
        {
            var values = await _appUserService.TUserListWithWorkLocation();
            var response = values.Select(user => new AppUserWorkLocationViewModel
            {
                Name = user.Name,
                Surname = user.Surname,
                WorkLocationId = user.WorkLocationId ?? 0,
                WorkLocationName = user.WorkLocation?.WorkLocationName,
                City = user.City,
                Country = user.Country,
                Gender = user.Gender,
                ImageUrl = user.ImageUrl
            }).ToList();
            return Ok(response);
        }
    }
}
