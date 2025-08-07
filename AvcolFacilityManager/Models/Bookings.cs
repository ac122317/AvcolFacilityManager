using AvcolFacilityManager.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolFacilityManager.Models
{
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }

        //This section represents an app user as a foreign key for this specific table, the app user must have a value as per the required validation attribute.
        [ForeignKey("AppUser"), Required]
        [Display(Name = "App User")]
        public string AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        //This section represents a facility as a foreign key for this specific table, the facility must have a value as per the required validation attribute.
        [ForeignKey("Facility"), Required]
        public int FacilityId { get; set; }
        public Facility? Facility { get; set; }

        //Date field is allocated the DataType annotation to allow only the date to be selected.
        [Required, DataType(DataType.Date)]
        public DateTime Date { get; set; }

        //StartTime field is allocated the DataType annotation to allow only the time to be selected.
        [Required, DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        //EndTime field is allocated the DataType annotation to allow only the time to be selected.
        [Required, DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
    }
}
