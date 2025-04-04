using Microsoft.EntityFrameworkCore;
using WatchStore.API.Models;

namespace WatchStore.API.Data
{
    public class WatchStoreDbContext : DbContext
    {
        public WatchStoreDbContext(DbContextOptions<WatchStoreDbContext> options) : base(options)
        {
        }
        public DbSet<Watch> Watches { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Watch>().HasData(
                new Watch
                {
                    Id = Guid.Parse("fe39a8ab-6637-4f91-babb-eb7bdfd28d99"),
                    Name = "Rolex Submariner",
                    Price = 1000,
                    Category = "Diving",
                    Stock = "10",
                    Description = "Rolex Watch",
                    ImageUrl = "https://via.placeholder.com/150",
                    ReleaseDate = new DateTime(2021, 1, 1),
                    BrandId = Guid.Parse("29837429-832f-43dd-b699-a05d45582b1f")
                }

            );
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = Guid.Parse("29837429-832f-43dd-b699-a05d45582b1f"),
                    Name = "Rolex",
                    Description = "Rolex Watch",
                    Country = "Switzerland",
                    LogoUrl = "https://via.placeholder.com/150"
                }
            );
        }
    }
}
