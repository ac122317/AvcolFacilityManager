using System.ComponentModel.DataAnnotations;

namespace AvcolFacilityManager.Models
{
    public class Facility
    {
        [Key]

        public int FacilityId { get; set; }

        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Facility name must only contain letters, number or spaces.")]
        public string FacilityName { get; set; }

        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Facility type must only contain letters, numbers or spaces.")]
        public string FacilityType { get; set; }

        [Required, Range(1, 3000)]
        public int Capacity { get; set; }

        public List<Bookings> Bookings { get; set; }
    }
}
