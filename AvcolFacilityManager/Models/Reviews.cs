using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolFacilityManager.Models
{
    public class Reviews
    {
        [Key]

        public int ReviewId { get; set; }

        [ForeignKey("Bookings"), Required(ErrorMessage = "Select your Booking.")]
        public int BookingId { get; set; }
        public Bookings Booking { get; set; }

        [Required(ErrorMessage = "Select your rating."), Range(1, 5)]
        public int Rating { get; set; }

        //Comment field that can be null.
        [MaxLength(200)]
        public string? Comment { get; set; }

        [Required]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
