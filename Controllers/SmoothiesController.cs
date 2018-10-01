using System.Collections.Generic;
using burgershack.Models;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SmoothiesController : Controller
  {
    List<Smoothie> smoothies;
    public SmoothiesController()
    {
      smoothies = new List<Smoothie>();
    }

    [HttpGet]
    public IEnumerable<Smoothie> Get()
    {
      return smoothies;
    }

    [HttpPost]
    public Smoothie Post([FromBody] Smoothie smoothie)
    {
      smoothies.Add(smoothie);
      return smoothie;
    }

  }

}