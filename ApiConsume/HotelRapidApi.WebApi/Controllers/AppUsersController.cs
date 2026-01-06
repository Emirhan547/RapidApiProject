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
        public async Task<IActionResult> GetUserListWithLocation()
        {
            var values=await _appUserService.TUserListWithWorkLocation();
            return Ok(values);
        }
        [HttpGet("AppUserList")]
        public async Task <IActionResult> GetUserList()
        {
            var values=await _appUserService.GetListAsync();
            return Ok(values);
        }
    }
}
