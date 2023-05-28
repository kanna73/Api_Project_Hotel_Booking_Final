using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Model
{
    public class Visitor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int visitorId { get; set; }
        public string? visitorName { get; set; }
        public int visitorPhone { get; set; }
        public string? visitorAddress { get; set; }


    }
}
