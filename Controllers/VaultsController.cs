using System.Collections.Generic;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;
using keepr.Models;
using System.Dynamic;

namespace keepr.Models
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsRepository _vr;

    public VaultsController(VaultsRepository vr)
    {
      _vr = vr;
    }

    [HttpGet]

    public ActionResult<IEnumerable<Vault>> Get()
    {
      string id = HttpContext.User.Identity.Name;
      dynamic user = new ExpandoObject();
      user.userId = id;
      IEnumerable<Vault> allVaults = _vr.GetAllVaults(user);
      if (allVaults == null)
      {
        return BadRequest("Failed to find vaults");
      }
      return Ok(allVaults);
    }

    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      Vault found = _vr.GetById(id);
      if (found == null) { return BadRequest("No vault found"); }
      return Ok(found);
    }

    [HttpPost]
    public ActionResult<Vault> Create([FromBody] Vault vault)
    {
      Vault newVault = _vr.CreateVault(vault);
      if (newVault == null) { return BadRequest("Vault creation failed"); }
      return Ok(newVault);
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _vr.Delete(id);
      if (!successful) { return BadRequest("Delete failed"); }
      return Ok();
    }
  }
}
