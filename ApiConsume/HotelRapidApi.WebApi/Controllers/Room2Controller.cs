using AutoMapper;
using HotelRapidApi.BusinessLayer.Abstract;

using HotelRapidApi.DtoLayer.DTOs.RoomDtos;
using HotelRapidApi.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public Room2Controller(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var values= await _roomService.GetListAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(CreateRoomDto roomAddDto)
        {
          await _roomService.CreateAsync(roomAddDto);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDto updateRoomDto)
        {
            _roomService.UpdateAsync(updateRoomDto);
            return Ok();
        }

    }
}
