using HotelProject.Data;
using HotelProject.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Services.VisitorService
{
    public class VisitorService:IVisitorService
    {
        public HotelDbContext _hotelDbContext;

        public VisitorService(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }
        public async Task<List<Visitor>> GetAllVisitorDetails()

        {
            var visitors = await _hotelDbContext.Visitors.ToListAsync();
            return visitors;
        }
        public async Task<Visitor> GetVisitor(int id)
        {
            var visitor = await _hotelDbContext.Visitors.FindAsync(id);
            if (visitor == null)
            {
                return null;
            }
            return visitor;
        }
        public async Task<List<Visitor>?> UpdateVisitor(int id, Visitor visitor)
        {
            var upvisitor = await _hotelDbContext.Visitors.FindAsync(id);
            if (upvisitor == null)
            {
                return null;
            }
            upvisitor.visitorId = visitor.visitorId;
            upvisitor.visitorName = visitor.visitorName;
            upvisitor.visitorPhone = visitor.visitorPhone;
            upvisitor.visitorAddress = visitor.visitorAddress;
            
            await _hotelDbContext.SaveChangesAsync();
            return await _hotelDbContext.Visitors.ToListAsync();
        }
        public async Task<List<Visitor>> AddVisitor(Visitor visitor)
        {
            _hotelDbContext.Visitors.Add(visitor);
            await _hotelDbContext.SaveChangesAsync();
            return await _hotelDbContext.Visitors.ToListAsync();
        }
        public async Task<List<Visitor>?> DeleteVisitor(int id)
        {
            var visitor = await _hotelDbContext.Visitors.FindAsync(id);
            if (visitor == null)
            {
                return null;
            }
            _hotelDbContext.Visitors.Remove(visitor);
            await _hotelDbContext.SaveChangesAsync();
            return await _hotelDbContext.Visitors.ToListAsync();
        }


    }
}
