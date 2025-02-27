using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvcolFacilityManager.Models
{
    public class Reviews
    {
        [Key]

        public int ReviewId { get; set; }

        [ForeignKey("User"), Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required, Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(200)]
        public string Comment { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
