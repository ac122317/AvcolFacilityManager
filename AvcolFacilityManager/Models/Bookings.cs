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
        public User user { get; set; }

        [ForeignKey("Facility"), Required]
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public TimeOnly StartTime { get; set; }

        [Required]
        public TimeOnly EndTime { get; set; }
    }
}
