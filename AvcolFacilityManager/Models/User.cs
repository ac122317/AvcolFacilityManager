using System.ComponentModel.DataAnnotations;

namespace AvcolFacilityManager.Models
{
    public class User
    {
        [Key]
        //Unique identifier for each user.
        public int UserId { get; set; }

        //User Last name field with several validation rules, an error message will display if at least one validation rule is not complied with (e.g., as per the regular expression the name must only have letters in it).
        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must only contain letters, no special characters or spaces.")]
        public string LastName { get; set; }

        //User First name field with several validation rules, an error message will display if at least one validation rule is not complied with (e.g., as per the regular expression the name must only have letters in it).
        [Required, MinLength(2), MaxLength(20), RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must only contain letters, no special characters or spaces.")]
        public string FirstName { get; set; }

        //User Email address field with several validation rules, an error message will display if at least one validation rule is not complied with (e.g., not in a correct email address format).
        [Required, MaxLength(35), EmailAddress]
        public string Email { get; set; }

        //User Phone Number field with validation rules, an error message will display if the regular expression (standard NZ phone number) format is not met.
        [Required, RegularExpression(@"^\+?\d{1,3}[- ]?\(?\d{3}\)?[- ]?\d{3}[- ]?\d{4}$", ErrorMessage = "Invalid phone number format (please include +64)")]
        public string Phone { get; set; }

        //List representing a one to many relationship - one user can make many reviews.
        public List<Reviews> Reviews { get; set; }

        //List representing a one to many relationship - one user can make many reviews.
        public List<Bookings> Bookings { get; set; }
    }
}
