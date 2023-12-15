namespace Animal_Shelter_Api.Models
{
  public class FuturePet
  {
    public int FuturePetId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Breed { get; set; }
    public string CoatColor { get; set; }
    public IFormFile Image { get; set; }

  }

  public class Cat : FuturePet
  {
    public bool FivPositive { get; set; }
    public string PetType => "Cat";
  }

  public class Dog : FuturePet
  {
    public string DogSize { get; set; }
    public string PetType => "Dog";
  }
  public class FuturePetDTO
  {
    public int FuturePetId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Breed { get; set; }
    public string CoatColor { get; set; }
    public bool? FivPositive { get; set; }
    public string DogSize { get; set; }
    public string PetType { get; set; }
    public IFormFile Image { get; set; }
  }
}