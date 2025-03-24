using AvcolFacilityManager.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolFacilityManager.Models
{
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }

        [ForeignKey("AppUser"), Required]
        [Display(Name = "App User")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        [ForeignKey("Facility"), Required]
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }

        //Date field is allocated the DataType annotation to allow only the date to be selected.
        [Required, DataType(DataType.Date)]
        public DateTime Date { get; set; }

        //StartTime field is allocated the DataType annotation to allow only the time to be selected.
        [Required, DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required, DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
    }
}
