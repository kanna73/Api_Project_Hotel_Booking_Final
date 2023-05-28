using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelProject.Data;
using HotelProject.Model;
using HotelProject.Services.ReservationService;
using Microsoft.AspNetCore.Authorization;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: api/Users

        [HttpGet]
        public async Task<ActionResult<List<Reservation>>> GetReservationDetails()
        {

            return await _reservationService.GetReservationDetails();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservationDetailsById(int id)
        {
            var res = await _reservationService.GetReservationDetailsById(id);
            if (res == null)
            {
                return NotFound("reservation_id Not Available");
            }
            return Ok(res);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, Reservation reservation )
        {
            var updatedRes = await _reservationService.UpdateReservation(id, reservation);
            if (updatedRes == null)
            {
                return NotFound("reservation_id Not Available");
            }
            return Ok(updatedRes);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservation>> AddReservation(Reservation reservation)
        {
            var newRes = await _reservationService.AddReservation(reservation);

            return Ok(newRes);
        }

        // DELETE: api/Users/5
        [HttpDelete("{resid}/{visId}")]
        public async Task<ActionResult<Reservation>> DeleteReservation(int resid,int visId)
        {
            var delRes = await _reservationService.DeleteReservationr(resid, visId);
            if (delRes == null)
            {
                return NotFound("reservation_id Not Available");
            }

            return Ok(delRes);

        }
    }
}
