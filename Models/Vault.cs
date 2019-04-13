using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Vault
  {
    public int id { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    public string description { get; set; }
    [Required]
    public string userId { get; set; }
  }
}