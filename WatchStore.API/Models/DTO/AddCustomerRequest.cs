using System.ComponentModel.DataAnnotations;

namespace WatchStore.API.Models.DTO
{
    public class AddCustomerRequest
    {
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Address { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Country { get; set; }
    }
}
