namespace Animal_Shelter_Api.Models
{
  public class FuturePet
  {
    public int FuturePetId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
  }

  public class Cat : FuturePet
  {
    public string Breed { get; set; }
    public string Color { get; set; }
    public bool FivPositive { get; set; }
  }
  public class Dog : FuturePet
  {
    public string Breed { get; set; }
    public string CoatColor { get; set; }
    public Size DogSize { get; set; }
  }
  public enum Size
  {
    Small,
    Medium,
    Large
  }
}