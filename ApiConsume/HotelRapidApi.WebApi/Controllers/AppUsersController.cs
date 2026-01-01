using HotelRapidApi.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController(IAppUserService _appUserService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUserListWithLocation()
        {
            var values=_appUserService.TUserListWithWorkLocation();
            return Ok(values);
        }
        [HttpGet("AppUserList")]
        public IActionResult GetUserList()
        {
            var values=_appUserService.TGetList();
            return Ok(values);
        }
    }
}
