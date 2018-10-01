namespace burgershack.Models
{
  public class Smoothie
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Smoothie(string name, string description, decimal price)
    {
      Name = name;
      Description = description;
      Price = price;
    }
  }
}