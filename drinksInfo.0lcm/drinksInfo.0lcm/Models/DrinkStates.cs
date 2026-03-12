using System.ComponentModel.DataAnnotations;

namespace drinksInfo._0lcm.Models;

public class FavoritedDrink
{
    public int Id { get; set; }

    [MaxLength(150)] public required string IdDrink { get; set; }

    [MaxLength(150)] public required string StrDrink { get; set; }

    public DateTime SavedAt { get; set; } = DateTime.Now;
}

public class ViewedDrink
{
    public int Id { get; set; }

    [MaxLength(150)] public required string IdDrink { get; set; }

    [MaxLength(150)] public required string StrDrink { get; set; }

    public int ViewCount { get; set; } = 1;
}