using HotelProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Services.VisitorFunctionService
{
    public interface IVisitorFunctionService
    {
        Task<object?> Filter(string location);
        Task<object> CountAvailableRoomsInHotel(int hotelId);
        
    }
}
