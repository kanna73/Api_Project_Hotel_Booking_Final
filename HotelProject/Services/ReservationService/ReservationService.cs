using HotelProject.Data;
using HotelProject.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Services.ReservationService
{
    public class ReservationService:IReservationService
    {
        public HotelDbContext _hotelDbContext;



        public ReservationService(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }
        public async Task<List<Reservation>> GetReservationDetails()
        {
            var rooms = await _hotelDbContext.Reservations.ToListAsync();
            return rooms;
        }

        public async Task<Reservation> GetReservationDetailsById(int id)
        {
            var room = await _hotelDbContext.Reservations.FindAsync(id);
            if (room == null)
            {
                return null;
            }
            return room;
        }
        public async Task<List<Reservation>?> UpdateReservation(int id, Reservation reservation)
        {
            var updateRes = await _hotelDbContext.Reservations.FindAsync(id);
            if (updateRes == null)
            {
                return null;
            }
            updateRes.ResId = reservation.ResId;
            updateRes.visitorId = reservation.visitorId;
            updateRes.RoomId = reservation.RoomId;
            updateRes.CheckInDate = reservation.CheckInDate;
            updateRes.CheckOutDate = reservation.CheckOutDate;

            await _hotelDbContext.SaveChangesAsync();
            return await _hotelDbContext.Reservations.ToListAsync();
        }
        public async Task<List<Reservation>> AddReservation(Reservation reservation)
        {
            _hotelDbContext.Reservations.Add(reservation);
            await _hotelDbContext.SaveChangesAsync();
            return await _hotelDbContext.Reservations.ToListAsync();
        }
        public async Task<List<Reservation>> DeleteReservationr(int resid,int visId)
        {
            //var delRes = await _hotelDbContext.Reservations.FindAsync(resid);
            //var delRes = _hotelDbContext.Reservations.Where(x => x.ResId == resid && x.UserId==userid);
            var delRes = await _hotelDbContext.Reservations.FirstOrDefaultAsync(x => x.ResId == resid && x.visitorId==visId);

            if (delRes == null)
            {
                return null;
            }
            _hotelDbContext.Reservations.Remove((Reservation)delRes);
            await _hotelDbContext.SaveChangesAsync();
            return await _hotelDbContext.Reservations.ToListAsync();
        }

    }
}
