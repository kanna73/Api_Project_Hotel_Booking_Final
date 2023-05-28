using HotelProject.Model;

namespace HotelProject.Services.RoomService
{
    public interface IRoomService
    {
        Task<List<Room>> GetRoomDetails();
        Task<Room> GetRoomDetailsById(int id);
        Task<List<Room>?> UpdateRoom(int id, Room room);
        Task<List<Room>> AddRoom(Room room);
        Task<List<Room>?> DeleteRoom(int id);
    }
}
