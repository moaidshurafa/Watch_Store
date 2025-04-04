using System.ComponentModel.DataAnnotations;

namespace WatchStore.API.Models.DTO
{
    public class UpdateWatchRequestDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name has to be a maximum of 50 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Description has to be a maximum of 500 characters")]
        public string Description { get; set; }
        [Required]
        [Range(0, 1000000, ErrorMessage = "Price has to be between 0 and 1000000")]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        [Range(0, 150, ErrorMessage = "Stock has to be between 0 and 150")]
        public string Stock { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public Guid BrandId { get; set; }
    }
}
