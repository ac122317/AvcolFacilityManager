using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolFacilityManager.Models
{
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }

        [ForeignKey("User"), Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Facility"), Required]
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required, DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required, DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
    }
}
