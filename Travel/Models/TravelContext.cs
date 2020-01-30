using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Travel.Controllers;
namespace Travel.Models
{
    public class TravelContext : IdentityDbContext<ApplicationUser>
    {
        public TravelContext(DbContextOptions<TravelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Place> Places{ get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Place>()
                .HasData(
                    new Place { PlaceId = 1, City = "Tokyo", Country = "Japan"},
                    new Place { PlaceId = 2, City = "Seattle", Country = "US"},
                    new Place { PlaceId = 3, City = "London", Country = "England"},
                    new Place { PlaceId = 4, City = "Taipei", Country = "Taiwan"},
                    new Place { PlaceId = 5, City = "Rio", Country = "Brazil"}
                );
            
            builder.Entity<Review>()
                .HasData(
                    new Review { ReviewId = 1, individualReview = "Great!", PlaceId = 1, Name = "Jake"},
                    new Review { ReviewId = 2, individualReview = "I hated this place!", PlaceId = 2, Name = "Shawn"},
                    new Review { ReviewId = 3, individualReview = "Highly recommend!!", PlaceId = 3, Name = "Leilani"},
                    new Review { ReviewId = 4, individualReview = "I loved this place. I will come back!", PlaceId =  4, Name = "Wei"},
                    new Review { ReviewId = 5, individualReview = "It was ok.", PlaceId = 5, Name = "Sharon"}
                );
        }
    }
}