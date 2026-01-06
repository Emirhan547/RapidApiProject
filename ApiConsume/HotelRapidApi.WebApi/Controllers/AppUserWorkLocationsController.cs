using Azure;
using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DataAccessLayer.Concrete;
using HotelRapidApi.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserWorkLocationsController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserWorkLocationsController(IAppUserService appUserService)
        {
            _appUserService = appUserService;

        }

        [HttpGet]

        public async Task<IActionResult> Index()
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