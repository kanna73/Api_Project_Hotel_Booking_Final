using HotelProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Services.HotelService
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetAllHotelDetails();
        Task<Hotel> GetHotel(int id);
        Task<List<Hotel>?> UpdateHotel(int id, Hotel hotel);
        Task<List<Hotel>> AddHotel(Hotel hotel);
        Task<List<Hotel>?> DeleteHotel(int id);
    }
}
