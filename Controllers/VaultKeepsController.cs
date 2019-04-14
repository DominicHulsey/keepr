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

    [HttpGet("{id}")]

    public ActionResult<IEnumerable<VaultKeeps>> Get(string id)
    {
      IEnumerable<VaultKeeps> allVaultKeeps = _vkr.GetAllVaultKeeps(id);
      if (allVaultKeeps == null)
      {
        return BadRequest("yo dawg there are no keeps in your vaults");
      }
      return Ok(allVaultKeeps);
    }

    //Add keep to vault
    [HttpPost("{id}")]
    public ActionResult<Vault> AddKeep([FromBody] VaultKeeps toAdd)
    {
      VaultKeeps newAdd = _vkr.AddToVault(toAdd);
      if (newAdd == null) { return BadRequest("Failed to add keep to vault!"); }
      return Ok(newAdd);
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _vkr.Delete(id);
      if (!successful) { return BadRequest("Delete failed!"); }
      return Ok();
    }
  }
}
