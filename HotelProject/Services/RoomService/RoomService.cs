using HotelProject.Data;
using HotelProject.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Services.RoomService
{
    public class RoomService:IRoomService
    {
        public HotelDbContext _hotelDbContext;



        public RoomService(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }
        public async Task<List<Room>> GetRoomDetails()
        {
            var rooms = await _hotelDbContext.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<Room> GetRoomDetailsById(int id)
        {
            var room = await _hotelDbContext.Rooms.FindAsync(id);
            if (room == null)
            {
                return null;
            }
            return room;
        }
        public async Task<List<Room>?> UpdateRoom(int id, Room room)
        {
            var updateRoom = await _hotelDbContext.Rooms.FindAsync(id);
            if (updateRoom == null)
            {
                return null;
            }
            updateRoom.RoomId = room.RoomId;
            updateRoom.HotelId = room.HotelId;
            updateRoom.RoomNumber = room.RoomNumber;
            updateRoom.RoomType = room.RoomType;
            updateRoom.RoomPrice = room.RoomPrice;
            updateRoom.RoomAvailability = room.RoomAvailability;



            await _hotelDbContext.SaveChangesAsync();
            return await _hotelDbContext.Rooms.ToListAsync();
        }
        public async Task<List<Room>> AddRoom(Room room)
        {
            _hotelDbContext.Rooms.Add(room);
            await _hotelDbContext.SaveChangesAsync();
            return await _hotelDbContext.Rooms.ToListAsync();
        }
        public async Task<List<Room>?> DeleteRoom(int id)
        {
            var room = await _hotelDbContext.Rooms.FindAsync(id);
            if (room == null)
            {
                return null;
            }
            _hotelDbContext.Rooms.Remove(room);
            await _hotelDbContext.SaveChangesAsync();
            return await _hotelDbContext.Rooms.ToListAsync();
        }


    }
}
