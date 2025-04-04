using System.ComponentModel.DataAnnotations;

namespace WatchStore.API.Models
{
    public class Watch
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Stock { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid BrandId { get; set; }

        // Navigation property
        public Brand Brand { get; set; }


    }
}
