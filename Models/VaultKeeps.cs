using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class VaultKeeps
  {
    public int id { get; set; }
    [Required]
    public int vaultId { get; set; }
    [Required]
    public int keepId { get; set; }
    [Required]
    public string userId { get; set; }
  }
}