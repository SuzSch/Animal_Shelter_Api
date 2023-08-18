using Microsoft.EntityFrameworkCore;

namespace Animal_Shelter_Api.Models
{
  public class Animal_Shelter_ApiContext : DbContext
  {
    public DbSet<FuturePet> FuturePets { get; set; }

    public Animal_Shelter_ApiContext(DbContextOptions<Animal_Shelter_ApiContext> options) : base(options)
    {
    }
  }
}