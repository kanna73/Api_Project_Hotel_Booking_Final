using HotelProject.Model;
using HotelProject.Services.HotelService;
using HotelProject.Services.ReservationService;
using HotelProject.Services.RoomService;
using HotelProject.Services.VisitorFunctionService;
using HotelProject.Services.VisitorService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]

    public class VisitorFunctionController : ControllerBase
    {
        private readonly IVisitorFunctionService _visitorFunctionService;

        public VisitorFunctionController(IVisitorFunctionService visitorFunctionService)
        {
            _visitorFunctionService = visitorFunctionService;
           
        }
        [HttpGet("ByLocation{location}")]
        public async Task<ActionResult<object>> Filter(string location)
        {
            var visitor = await _visitorFunctionService.Filter(location);
            if (visitor == null)
            {
                return NotFound("visitor_id Not Available");
            }
            return Ok(visitor);
        }
        [HttpGet("ByHotelId{hotelId}")]
        public async Task<ActionResult<object>> CountAvailableRoomsInHotel(int hotelId)
        {
            var avilableRooms = await _visitorFunctionService.CountAvailableRoomsInHotel(hotelId);
            if (avilableRooms == null)
            {
                return NotFound("Hotel_id Not Available");
            }
            return Ok(avilableRooms);
        }
        
    }
}
