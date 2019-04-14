using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class VaultKeeps
  {
    public int id { get; set; }
    [Required]
    public string vaultId { get; set; }
    [Required]
    public string keepId { get; set; }
    [Required]
    public string userId { get; set; }
  }
}