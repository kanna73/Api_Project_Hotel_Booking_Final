using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProject.Model
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int ResId { get; set; }
        [ForeignKey("Visitor")]

        public int visitorId { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set;}
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CheckInDate { get; set; }
        [Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CheckOutDate { get; set; }




    }
}
