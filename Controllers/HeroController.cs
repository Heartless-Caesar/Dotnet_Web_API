using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data;

namespace MyWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HeroController : ControllerBase
{
    private readonly AppDbContext _context;
    public HeroController(AppDbContext dbContext)
    {
        _context = dbContext;
    }
    
    //GET entire hero list
    [HttpGet]
    public async Task<ActionResult<List<Hero>>> GetHero()
    {
        var fullList = await _context.Heroes.ToListAsync();
        return Ok(fullList);
    }
    
    //GET single hero
    [HttpGet("/api/Hero/{id}")]
    public async Task<ActionResult<Hero>> GetHero(int id)
    {
        var singleHero = await _context.Heroes.FindAsync(id);
        
        if (singleHero == null) return BadRequest("No element with id of {id}");
        
        return Ok(singleHero);
    }
    
    //POST single hero
    [HttpPost("/api/Hero")]
    public async Task<ActionResult<List<Hero>>> AddHero(Hero obj)
    {
        _context.Heroes.Add(obj);
        await _context.SaveChangesAsync();
        var updatedList = await _context.Heroes.ToListAsync();
        return Ok(updatedList);
    }
    
    //Update single hero
    [HttpPut]
    public async Task<ActionResult<Hero>> UpdateHero(Hero req)
    {
        var hero = await _context.Heroes.FindAsync(req.Id);
        if (hero == null) return BadRequest("Element not found");

        hero.FirstName = req.FirstName;
        hero.LastName = req.LastName;
        hero.Power = req.Power;

        await _context.SaveChangesAsync();
        
        var updatedList = await _context.Heroes.ToListAsync();
        
        return Ok(updatedList);
    }
    
    //Delete single hero
    [HttpDelete("/api/Hero/{id}")]
    public async Task<ActionResult<Hero>> DeleteHero(int? id)
    {
        var hero = await _context.Heroes.FindAsync(id);
        if (hero == null) return BadRequest("There is no element with id of {id}");

        _context.Heroes.Remove(hero);
        await _context.SaveChangesAsync();
        
        return Ok("Element deleted");
    }
    
}