using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProject.Model
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int RoomId { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public int RoomNumber { get; set; }
        public string? RoomType { get; set; }
        public int RoomPrice { get; set; }
        public string? RoomAvailability { get; set; }



    }
}
