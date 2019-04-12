using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
  {
    public int id { get; set; }
    [Required]
    public string keepTitle { get; set; }

    [Required]
    public string img { get; set; }
    public int views { get; set; }
    public int timesShared { get; set; }


  }
}