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
    public async Task<ActionResult<IEnumerable<FuturePetDTO>>> Get(string petType, int minAge)
    {
      IQueryable<FuturePet> query = _db.FuturePets.AsQueryable();

      if (!string.IsNullOrEmpty(petType))
      {
        query = query.Where(pet => (petType == "cat" && pet is Cat) || (petType == "dog" && pet is Dog));
      }
      if (minAge > 0)
      {
        query = query.Where(entry => entry.Age >= minAge);
      }

      List<FuturePet> futurePets = await query.ToListAsync();
      List<FuturePetDTO> futurePetDTOs = futurePets.Select(pet =>
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
            Image = cat.Image,
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
            Image = dog.Image,
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
          Image = cat.Image,
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
          Image = dog.Image,
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
          FivPositive = futurePetDTO.FivPositive ?? false,
          Image = futurePetDTO.Image,
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
          DogSize = futurePetDTO.DogSize,
          Image = futurePetDTO.Image,
        };
      }
      else
      {
        return BadRequest("Invalid pet type.");
      }

      _db.FuturePets.Add(futurePet);
      await _db.SaveChangesAsync();

      FuturePetDTO responseDTO = new FuturePetDTO
      {
        FuturePetId = futurePet.FuturePetId,
        Name = futurePet.Name,
        Age = futurePet.Age,
        Breed = futurePet.Breed,
        CoatColor = futurePet.CoatColor,
        Image = futurePet.Image,
        FivPositive = (futurePet is Cat cat) ? cat.FivPositive : (bool?)null,
        DogSize = (futurePet is Dog dog) ? dog.DogSize : null,
        PetType = (futurePet is Cat) ? "Cat" : ((futurePet is Dog) ? "Dog" : null)
      };
      return CreatedAtAction(nameof(GetFuturePet), new { id = responseDTO.FuturePetId }, responseDTO);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutFuturePet(int id, [FromBody] FuturePetDTO updatedFuturePetDTO)
    {
      FuturePet existingFuturePet = await _db.FuturePets.FindAsync(id);

      if (existingFuturePet == null)
      {
        return NotFound();
      }

      if (existingFuturePet is Cat existingCat && updatedFuturePetDTO.PetType == "Cat")
      {
        existingCat.Name = updatedFuturePetDTO.Name;
        existingCat.Age = updatedFuturePetDTO.Age;
        existingCat.Breed = updatedFuturePetDTO.Breed;
        existingCat.CoatColor = updatedFuturePetDTO.CoatColor;
        existingCat.Image = updatedFuturePetDTO.Image;
        existingCat.FivPositive = updatedFuturePetDTO.FivPositive ?? false;

        await _db.SaveChangesAsync();
        return NoContent();
      }
      else if (existingFuturePet is Dog existingDog && updatedFuturePetDTO.PetType == "Dog")
      {
        existingDog.Name = updatedFuturePetDTO.Name;
        existingDog.Age = updatedFuturePetDTO.Age;
        existingDog.Breed = updatedFuturePetDTO.Breed;
        existingDog.CoatColor = updatedFuturePetDTO.CoatColor;
        existingDog.Image = updatedFuturePetDTO.Image;
        existingDog.DogSize = updatedFuturePetDTO.DogSize;

        await _db.SaveChangesAsync();
        return NoContent();
      }
      else
      {
        return BadRequest("Invalid pet type or update data.");
      }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFuturePet(int id)
    {
      FuturePet futurePet = await _db.FuturePets.FindAsync(id);

      if (futurePet == null)
      {
        return NotFound();
      }

      _db.FuturePets.Remove(futurePet);
      await _db.SaveChangesAsync();

      return NoContent();
    }


  }
}
