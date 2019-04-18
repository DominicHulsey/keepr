using System.Collections.Generic;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;
using keepr.Models;

namespace keepr.Models
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsRepository _vkr;

    public VaultKeepsController(VaultKeepsRepository vkr)
    {
      _vkr = vkr;
    }

    [HttpGet("{vaultId}/keeps")]

    public ActionResult<IEnumerable<Keep>> Get(int vaultId)
    {
      string userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> VaultKeeps = _vkr.GetVaultKeeps(vaultId, userId);
      if (VaultKeeps == null)
      {
        return BadRequest("yo dawg there are no keeps in your vaults");
      }
      return Ok(VaultKeeps);
    }

    //Add keep to vault
    [HttpPost("{vaultId}")]
    public ActionResult<Vault> AddKeep([FromBody] VaultKeeps toAdd)
    {
      VaultKeeps newAdd = _vkr.AddToVault(toAdd);
      if (newAdd == null) { return BadRequest("Failed to add keep to vault!"); }
      return Ok(newAdd);
    }

    [HttpDelete("{vaultId}/deletekeep/{keepId}")]
    public ActionResult<string> Delete(int vaultId, int keepId)
    {
      string userId = HttpContext.User.Identity.Name;
      bool successful = _vkr.Delete(vaultId, keepId, userId);
      if (!successful) { return BadRequest("Delete failed!"); }
      return Ok();
    }
  }
}
