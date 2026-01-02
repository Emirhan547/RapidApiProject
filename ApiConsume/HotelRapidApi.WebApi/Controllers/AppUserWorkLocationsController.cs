using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Concrete;
using HotelRapidApi.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserWorkLocationsController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly AppDbContext _appDbContext;
        public AppUserWorkLocationsController(IAppUserService appUserService, AppDbContext appDbContext)
        {
            _appUserService = appUserService;
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //var values = _appUserService.TUsersListWithWorkLocations();

            var values = _appDbContext.Users.Include(x => x.WorkLocation).Select(y => new AppUserWorkLocationViewModel
            {
                Name = y.Name,
                Surname = y.Surname,
                WorkLocationId = y.WorkLocationId,
                WorkLocationName = y.WorkLocation.WorkLocationName,
                City = y.City,
                Country = y.Country,
                Gender = y.Gender,
                ImageUrl = y.ImageUrl
            }).ToList(); 
            return Ok(values);
        }

    }
}
