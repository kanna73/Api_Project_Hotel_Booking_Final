using HotelProject.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Data
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<User> Users { get; set; }
    }
}
