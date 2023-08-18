using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Animal_Shelter_Api.Models;

namespace Animal_Shelter_Api.Controllers
{
  [Route("api"[controller])]
  [ApiController]
  public class FuturePetsController : ControllerBase
  {
    private readonly Animal_Shelter_ApiContext _db;
    public FuturePetsController(Animal_Shelter_ApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FuturePet>>> Get()
    {
      return await _db.FuturePets.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FuturePet>> GetFuturePets(int id)
    {
      FuturePet futurePet = await _db.FuturePets.FindAsync(id);

      if (futurePet == null)
      {
        return NotFound();
      }
      return futurePet;
    }
  }
}
