using System.ComponentModel.DataAnnotations;

namespace WatchStore.API.Models.DTO
{
    public class AddReviewRequestDTO
    {
        [Required]
        public Guid WatchId { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Comment has to be a maximum of 500 characters")]
        public string Comment { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
    }
}
