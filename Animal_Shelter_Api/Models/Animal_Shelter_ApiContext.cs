using Microsoft.EntityFrameworkCore;

namespace Animal_Shelter_Api.Models
{
  public class Animal_Shelter_ApiContext : DbContext
  {
    public DbSet<FuturePet> FuturePets { get; set; }
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Dog> Dogs { get; set; }

    public Animal_Shelter_ApiContext(DbContextOptions<Animal_Shelter_ApiContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Cat>()
        .HasData(
          new Cat { FuturePetId = 1, Name = "Coco", Age = 1, Breed = "Siamese", CoatColor = "White", FivPositive = false },
          new Cat { FuturePetId = 2, Name = "Tuffy", Age = 3, Breed = "Ragamuffin", CoatColor = "Chestnut", FivPositive = true },
          new Cat { FuturePetId = 3, Name = "Fernando", Age = 3, Breed = "Maine Coon", CoatColor = "Grey", FivPositive = false }
        );
      builder.Entity<Dog>()
      .HasData(
          new Dog { FuturePetId = 4, Name = "Bing", Age = 4, Breed = "Corgi", CoatColor = "Sable", DogSize = "Small" },
          new Dog { FuturePetId = 5, Name = "Mushroom", Age = 3, Breed = "Pug", CoatColor = "Brindle", DogSize = "Small" },
          new Dog { FuturePetId = 6, Name = "Felix", Age = 1, Breed = "Great Pyrenees", CoatColor = "Red", DogSize = "Large" }
        );

    }
  }
}