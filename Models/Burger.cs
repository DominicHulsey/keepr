using System;
using System.ComponentModel.DataAnnotations;

namespace burgershack.Models
{
  public class Burger
  {
    private Burger burger;

    public Guid Id { get; set; }
    [Required]
    [MinLength(6)]
    public string Name { get; set; }
    [MaxLength(255)]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }

    public Burger(string name, string description, decimal price = 5.00m)
    {
      Id = Guid.NewGuid();
      Name = name;
      Description = description;
      if (price > 5)
      {
        Price = price;
      }
      else
      {
        Price = 5;
      }
    }

  }
}