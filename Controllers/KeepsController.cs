using System.Collections.Generic;
using System.Dynamic;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Models
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsRepository _pr;

    public KeepsController(KeepsRepository pr)
    {
      _pr = pr;
    }

    [HttpGet]
    //gets all public keeps
    public ActionResult<IEnumerable<Keep>> Get()
    {
      IEnumerable<Keep> allKeeps = _pr.GetAllKeeps();
      if (allKeeps == null)
      {
        return BadRequest("there are no keeps");
      }
      return Ok(allKeeps);
    }
    [HttpGet("private")]
    //gets all public keeps
    public ActionResult<IEnumerable<Keep>> GetPrivate()
    {
      string userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> allKeeps = _pr.GetPrivateKeeps(userId);
      if (allKeeps == null)
      {
        return BadRequest("Failed to get private keeps!");
      }
      return Ok(allKeeps);
    }

    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      Keep found = _pr.GetById(id);
      if (found == null)
      {
        return BadRequest("No keep found at that ID!");
      };
      return Ok(found);
    }

    [HttpPost]
    public ActionResult<Keep> Create([FromBody] Keep keep)
    {
      keep.userId = HttpContext.User.Identity.Name;
      Keep newKeep = _pr.CreateKeep(keep);
      if (newKeep == null) { return BadRequest("Keep creation failed!"); }
      return Ok(newKeep);
    }

    [HttpPost("{id}/views")]
    public ActionResult<Keep> addView([FromBody] Keep keep)
    {
      Keep updated = _pr.addView(keep);
      if (updated == null) { return BadRequest("Adding view failed!"); }
      return Ok(updated);
    }

    [HttpPost("{id}/shares")]
    public ActionResult<Keep> addShare([FromBody] Keep keep)
    {
      Keep updated = _pr.addShare(keep);
      if (updated == null) { return BadRequest("Adding share failed!"); }
      return Ok(updated);
    }
    [HttpPost("{id}/keeps")]
    public ActionResult<Keep> addKeep([FromBody] Keep keep)
    {
      Keep updated = _pr.addKeep(keep);
      if (updated == null) { return BadRequest("Adding keep failed!"); }
      return Ok(updated);
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _pr.Delete(id);
      if (!successful) { return BadRequest("Delete failed!"); }
      return Ok();
    }
  }
}
