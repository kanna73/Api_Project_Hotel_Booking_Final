using HotelProject.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;

namespace HotelProject.Data
{
    public class HotelDbContext:DbContext
    {
        public DbSet<Visitor> Visitors { get; set; }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Reservation> Reservations{ get; set; }



        public HotelDbContext(DbContextOptions<HotelDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
