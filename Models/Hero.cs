using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.Models;

public class Hero
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Power { get; set; } = string.Empty;
}