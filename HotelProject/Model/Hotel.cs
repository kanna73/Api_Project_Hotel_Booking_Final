using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Model
{
    public class Hotel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public int HotelContactNo { get; set; }

        public string? HotelAddress { get; set; }
        public string? HotelDetails { get; set; }
        public string? RoomAvailability { get; set; }

    }
}
