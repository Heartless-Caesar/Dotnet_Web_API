using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){} 
}