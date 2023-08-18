using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Animal_Shelter_Api.Models;

namespace Animal_Shelter_Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FuturePetsController : ControllerBase
  {
    private readonly Animal_Shelter_ApiContext _db;
    public FuturePetsController(Animal_Shelter_ApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FuturePetDTO>>> Get()
    {
      var futurePets = await _db.FuturePets.ToListAsync();
      var futurePetDTOs = futurePets.Select(pet =>
      {
        if (pet is Cat cat)
        {
          return new FuturePetDTO
          {
            FuturePetId = cat.FuturePetId,
            Name = cat.Name,
            Age = cat.Age,
            Breed = cat.Breed,
            CoatColor = cat.CoatColor,
            FivPositive = cat.FivPositive,
            PetType = cat.PetType
          };
        }
        else if (pet is Dog dog)
        {
          return new FuturePetDTO
          {
            FuturePetId = dog.FuturePetId,
            Name = dog.Name,
            Age = dog.Age,
            Breed = dog.Breed,
            CoatColor = dog.CoatColor,
            DogSize = dog.DogSize,
            PetType = dog.PetType
          };
        }
        else
        {
          return null;
        }
      }).ToList();
      return futurePetDTOs;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<FuturePetDTO>> GetFuturePet(int id)
    {
      FuturePet futurePet = await _db.FuturePets.FindAsync(id);

      if (futurePet == null)
      {
        return NotFound();
      }

      FuturePetDTO futurePetDTO;

      if (futurePet is Cat cat)
      {
        futurePetDTO = new FuturePetDTO
        {
          FuturePetId = cat.FuturePetId,
          Name = cat.Name,
          Age = cat.Age,
          Breed = cat.Breed,
          CoatColor = cat.CoatColor,
          FivPositive = cat.FivPositive,
          PetType = cat.PetType
        };
      }
      else if (futurePet is Dog dog)
      {
        futurePetDTO = new FuturePetDTO
        {
          FuturePetId = dog.FuturePetId,
          Name = dog.Name,
          Age = dog.Age,
          Breed = dog.Breed,
          CoatColor = dog.CoatColor,
          DogSize = dog.DogSize,
          PetType = dog.PetType
        };
      }
      else
      {
        return BadRequest("Invalid pet type.");
      }
      return futurePetDTO;
    }
    [HttpPost]
    public async Task<ActionResult<FuturePetDTO>> Post([FromBody] FuturePetDTO futurePetDTO)
    {
      FuturePet futurePet;

      if (futurePetDTO.PetType == "Cat")
      {
        futurePet = new Cat
        {
          Name = futurePetDTO.Name,
          Age = futurePetDTO.Age,
          Breed = futurePetDTO.Breed,
          CoatColor = futurePetDTO.CoatColor,
          FivPositive = futurePetDTO.FivPositive ?? false
        };
      }
      else if (futurePetDTO.PetType == "Dog")
      {
        futurePet = new Dog
        {
          Name = futurePetDTO.Name,
          Age = futurePetDTO.Age,
          Breed = futurePetDTO.Breed,
          CoatColor = futurePetDTO.CoatColor,
          DogSize = futurePetDTO.DogSize
        };
      }
      else
      {
        return BadRequest("Invalid pet type.");
      }

      _db.FuturePets.Add(futurePet);
      await _db.SaveChangesAsync();

      var responseDTO = new FuturePetDTO
      {
        FuturePetId = futurePet.FuturePetId,
        Name = futurePet.Name,
        Age = futurePet.Age,
        Breed = futurePet.Breed,
        CoatColor = futurePet.CoatColor,
        FivPositive = (futurePet is Cat cat) ? cat.FivPositive : (bool?)null,
        DogSize = (futurePet is Dog dog) ? dog.DogSize : null,
        PetType = (futurePet is Cat) ? "Cat" : ((futurePet is Dog) ? "Dog" : null)
      };
      return CreatedAtAction(nameof(GetFuturePet), new { id = responseDTO.FuturePetId }, responseDTO);
    }
  }
}
