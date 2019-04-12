using System.Collections.Generic;
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

    public ActionResult<IEnumerable<Keep>> Get()
    {
      IEnumerable<Keep> allKeeps = _pr.GetAllKeeps();
      if (allKeeps == null)
      {

        return BadRequest("yo dawg there are no keeps");
      }
      return Ok(allKeeps);
    }

    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      Keep found = _pr.GetById(id);
      if (found == null) { return BadRequest("No keep found at that ID!"); }
      return Ok(found);
    }

    [HttpPost]

    public ActionResult<Keep> Create([FromBody] Keep keep)
    {
      Keep newKeep = _pr.CreateKeep(keep);
      if (newKeep == null) { return BadRequest("Keep creation failed!"); }
      return Ok(newKeep);
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
