using System.ComponentModel.DataAnnotations;

namespace WatchStore.API.Models.DTO
{
    public class AddBrandRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Description has to be a maximum of 500 characters")]
        public string Description { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string LogoUrl { get; set; }
    }
}
