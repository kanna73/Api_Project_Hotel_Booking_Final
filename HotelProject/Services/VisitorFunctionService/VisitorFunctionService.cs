using HotelProject.Data;
using HotelProject.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Services.VisitorFunctionService
{
    public class VisitorFunctionService: IVisitorFunctionService
    {
        public HotelDbContext _hotelDbContext;

        public VisitorFunctionService(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }
        public async Task<object?> Filter(string location)
        {
            var reqHotel = await _hotelDbContext.Hotels.FirstOrDefaultAsync(x => x.HotelAddress == location);
            return reqHotel.HotelName;
        }
        public async Task<object> CountAvailableRoomsInHotel(int hotelId)
        {
            var countOfAvailableRooms= await _hotelDbContext.Rooms.CountAsync(x => x.HotelId == hotelId && x.RoomAvailability=="Available");
            return countOfAvailableRooms;
        }
        

    }
}
