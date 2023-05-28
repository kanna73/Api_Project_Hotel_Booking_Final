using HotelProject.Model;

namespace HotelProject.Services.VisitorService
{
    public interface IVisitorService
    {
        Task<List<Visitor>> GetAllVisitorDetails();
        Task<Visitor> GetVisitor(int id);
        Task<List<Visitor>?> UpdateVisitor(int id, Visitor visitor);
        Task<List<Visitor>> AddVisitor(Visitor visitor);
        Task<List<Visitor>?> DeleteVisitor(int id);
    }
}
