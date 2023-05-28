using HotelProject.Model;

namespace HotelProject.Services.ReservationService
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetReservationDetails();
        Task<Reservation> GetReservationDetailsById(int id);
        Task<List<Reservation>?> UpdateReservation(int id, Reservation reservation);
        Task<List<Reservation>> AddReservation(Reservation reservation);
        Task<List<Reservation>> DeleteReservationr(int resid,int visId);
    }
}
