using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelProject.Data;
using HotelProject.Model;
using HotelProject.Services.HotelService;
using Microsoft.AspNetCore.Authorization;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> GetAllHotelDetails()
        {

            return await _hotelService.GetAllHotelDetails();
        }


        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _hotelService.GetHotel(id);
            if (hotel == null)
            {
                return NotFound("hotel_id Not Available");
            }
            return Ok(hotel);
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, Hotel hotel)
        {
            var Uphotel = await _hotelService.UpdateHotel(id, hotel);
            if (Uphotel == null)
            {
                return NotFound("hotel_id Not Available");
            }
            return Ok(Uphotel);

        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> AddHotel(Hotel hotel)
        {
            var newHotel = await _hotelService.AddHotel(hotel);
           

            return Ok(newHotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var deleteHotel = await _hotelService.DeleteHotel(id);
            if (deleteHotel == null)
            {
                return NotFound("hotel_id Not Available");
            }

            return Ok(deleteHotel);
        }

        
    }
}
