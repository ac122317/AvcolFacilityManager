using System.ComponentModel.DataAnnotations;

namespace AvcolFacilityManager.Models
{
    public class Facility
    {
        [Key]

        public int FacilityId { get; set; }

        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must only contain letters, no special characters or spaces.")]
        public string FacilityName { get; set; }

        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must only contain letters, no special characters or spaces.")]
        public string FacilityType { get; set; }

        [Required, Range(1, 1000)]
        public int Capacity { get; set; }

        public List<Bookings> Bookings { get; set; }
    }
}
