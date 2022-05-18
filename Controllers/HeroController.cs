using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HeroController : ControllerBase
{
    //Default example value
    private static List<Hero> heroes = new List<Hero>
    {
        new Hero { 
            Id = 1,
            FirstName = "Luthor",
            LastName = "Strode",
            Power = "Strength"
                
        }
    };
    
    [HttpGet]
    public async Task<ActionResult<List<Hero>>> GetHero()
    {
        

        return Ok(heroes);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<Hero>>> AddHero(Hero obj)
    {
        heroes.Add(obj);
      
        return Ok(heroes);
    }
}