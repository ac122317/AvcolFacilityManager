using System.ComponentModel.DataAnnotations;

namespace AvcolFacilityManager.Models
{
    public class Facility
    {
        //Unique identifier for each Facility
        [Key]
        public int FacilityId { get; set; }

        //Facility name field with several validation rules, an error message will display if at least one validation rule is not complied with (e.g., as per the maxlength annotation, the name of the facility must not exceed 20 characters).
        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Facility name must only contain letters, number or spaces.")]
        [Display (Name = "Facility Name")]
        public string FacilityName { get; set; }

        //Facility type field with several validation rules, an error message will display if at least one validation rule is not complied with (e.g., as per the maxlength annotation, the type of the facility must not exceed 20 characters).
        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Facility type must only contain letters or numbers.")]
        [Display(Name = "Facility Type")]
        public string FacilityType { get; set; }

        //Capacity field is allocated the range data annotation so that the field only accepts inputs between 1 and 3000 characters.
        [Required, Range(1, 3000)]
        public int Capacity { get; set; }

        //List representing a one to many relationship - one facility can be booked many times.
        public List<Bookings>? Bookings { get; set; }
    }
}
