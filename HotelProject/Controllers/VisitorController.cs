using HotelProject.Model;
using HotelProject.Services.HotelService;
using HotelProject.Services.VisitorService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VisitorController : ControllerBase
    {
        private readonly IVisitorService _visitorService;

        public VisitorController(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<List<Visitor>>> GetAllVisitorDetails()
        {

            return await _visitorService.GetAllVisitorDetails();
        }


        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visitor>> GetVisitor(int id)
        {
            var visitor = await _visitorService.GetVisitor(id);
            if (visitor == null)
            {
                return NotFound("visitor_id Not Available");
            }
            return Ok(visitor);
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVisitor(int id, Visitor visitor)
        {
            var UpVisitor = await _visitorService.UpdateVisitor(id, visitor);
            if (UpVisitor == null)
            {
                return NotFound("visitor_id Not Available");
            }
            return Ok(UpVisitor);

        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Visitor>> AddVisitor(Visitor visitor)
        {
            var newVisitor = await _visitorService.AddVisitor(visitor);


            return Ok(newVisitor);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var deleteVisitor = await _visitorService.DeleteVisitor(id);
            if (deleteVisitor == null)
            {
                return NotFound("hotel_id Not Available");
            }

            return Ok(deleteVisitor);
        }


    }
}
