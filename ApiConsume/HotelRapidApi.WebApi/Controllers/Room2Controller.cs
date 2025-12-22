using AutoMapper;
using HotelRapidApi.BusinessLayer.Abstract;
using HotelRapidApi.DtoLayer.DTOs.RoomDto;
using HotelRapidApi.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public IActionResult Index()
        {
            var values=_roomService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRoom(RoomAddDto roomAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
             }
            var values=_mapper.Map<Room>(roomAddDto);
            _roomService.TInsert(values);

            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDto updateRoomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values=_mapper.Map<Room>(updateRoomDto);
            _roomService.TUpdate(values);
            return Ok("Başarıyla Güncellendi");
        }

    }
}
