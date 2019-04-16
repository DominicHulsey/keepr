using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
  {
    [Required]
    public string userId { get; set; }
    public int id { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    public string description { get; set; }

    [Required]
    public string img { get; set; }
    public bool isPrivate { get; set; }
    public int views { get; set; }
    public int shares { get; set; }
    public int keeps { get; set; }


  }
}