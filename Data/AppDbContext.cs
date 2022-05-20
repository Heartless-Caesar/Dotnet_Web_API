using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;

namespace MyWebAPI.Data;

public class AppDbContext : DbContext
{
#pragma warning disable CS8618
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
#pragma warning restore CS8618

    public DbSet<Hero> Heroes { get; set; }
}