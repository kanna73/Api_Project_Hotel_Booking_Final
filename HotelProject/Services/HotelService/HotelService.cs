using HotelProject.Data;
using HotelProject.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Services.HotelService
{
    public class HotelService: IHotelService
    {
        public HotelDbContext _hotelDbContext;


        
        public HotelService(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }
        public async Task<List<Hotel>> GetAllHotelDetails()

        {
            var hotels = await _hotelDbContext.Hotels.ToListAsync();
            return hotels;
        }
        public async Task<Hotel> GetHotel(int id)
        {
            var hotel = await _hotelDbContext.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return null;
            }
            return hotel;
        }
        public async Task<List<Hotel>?> UpdateHotel(int id, Hotel hotel)
        {
            var uphotel = await _hotelDbContext.Hotels.FindAsync(id);
            if (uphotel == null)
            {
                return null;
            }
            uphotel.HotelId = hotel.HotelId;
            uphotel.HotelName = hotel.HotelName;
            uphotel.HotelContactNo= hotel.HotelContactNo;
            uphotel.HotelAddress = hotel.HotelAddress;
            uphotel.HotelDetails = hotel.HotelDetails;
            uphotel.RoomAvailability = hotel.RoomAvailability;
            await _hotelDbContext.SaveChangesAsync();
            return await _hotelDbContext.Hotels.ToListAsync();
        }
        public async Task<List<Hotel>> AddHotel(Hotel hotel)
        {
            _hotelDbContext.Hotels.Add(hotel);
            await _hotelDbContext.SaveChangesAsync();
            return await _hotelDbContext.Hotels.ToListAsync();
        }
        public async Task<List<Hotel>?> DeleteHotel(int id)
        {
            var hotel = await _hotelDbContext.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return null;
            }
            _hotelDbContext.Hotels.Remove(hotel);
            await _hotelDbContext.SaveChangesAsync();
            return await _hotelDbContext.Hotels.ToListAsync();
        }



    }
}
