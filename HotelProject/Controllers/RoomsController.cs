using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelProject.Data;
using HotelProject.Model;
using HotelProject.Services.RoomService;
using Microsoft.AspNetCore.Authorization;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles="Admin")]

    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/Users

        [HttpGet]
        public async Task<ActionResult<List<Room>>> GetRoomDetails()
        {

            return await _roomService.GetRoomDetails();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoomDetailsById(int id)
        {
            var room = await _roomService.GetRoomDetailsById(id);
            if (room == null)
            {
                return NotFound("room_id Not Available");
            }
            return Ok(room);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, Room room)
        {
            var updatedRoom = await _roomService.UpdateRoom(id, room);
            if (updatedRoom == null)
            {
                return NotFound("room_id Not Available");
            }
            return Ok(updatedRoom);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> AddRoom(Room room)
        {
            var newRoom = await _roomService.AddRoom(room);

            return Ok(newRoom);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            var oldroom = await _roomService.DeleteRoom(id);
            if (oldroom == null)
            {
                return NotFound("room_id Not Available");
            }

            return Ok(oldroom);

        }

    }
}
