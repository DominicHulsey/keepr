using System;
using System.ComponentModel.DataAnnotations;

namespace burgershack.Models
{
  public class Burger
  {
    public int Id { get; set; }
    [Required]
    [MinLength(6)]
    public string Name { get; set; }
    [Required]
    [MaxLength(255)]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }

    public Burger() { }
    public Burger(string name, string description, decimal price = 5.00m)
    {
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