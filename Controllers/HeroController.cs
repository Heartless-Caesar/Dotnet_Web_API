using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data;

namespace MyWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HeroController : ControllerBase
{
    private readonly DbContext _context;
    
    //Default example value
    private static List<Hero> heroes = new List<Hero>
    {
        new Hero { 
            Id = 1,
            FirstName = "Luthor",
            LastName = "Strode",
            Power = "Strength"
                
        },
        new Hero { 
            Id = 2,
            FirstName = "Mark",
            LastName = "Thatch",
            Power = "Acute Reflexes"
                
        }
    };

    public HeroController(AppDbContext context)
    {
        _context = context;
    }
    
    //GET entire hero list
    [HttpGet]
    public async Task<ActionResult<List<Hero>>> GetHero()
    {
        
        return Ok(heroes);
    }
    
    //GET single hero
    [HttpGet("/api/Hero/{id}")]
    public async Task<ActionResult<Hero>> GetHero(int? id)
    {
        var hero = heroes.Find(x => x.Id == id);
            if (hero == null) return BadRequest("Hero not found");
        return Ok(hero);
    }
    
    //POST single hero
    [HttpPost]
    public async Task<ActionResult<List<Hero>>> AddHero(Hero obj)
    {
        heroes.Add(obj);
      
        return Ok(heroes);
    }
    
    //Update single hero
    [HttpPut]
    public async Task<ActionResult<Hero>> UpdateHero(Hero req)
    {
        var hero = heroes.Find(x => x.Id == req.Id);
        if (hero == null) return BadRequest("Hero not found");

        hero.FirstName = req.FirstName;
        hero.LastName = req.LastName;
        hero.Power = req.Power;

        return Ok(heroes);
    }
    
    //Delete single hero
    [HttpDelete("/api/Hero/{id}")]
    public async Task<ActionResult<Hero>> DeleteHero(int? id)
    {
        var hero = heroes.Find(x => x.Id == id);
        if (hero == null) return BadRequest("Hero not found");

        heroes.Remove(hero);

        return Ok(heroes);
    }
    
}