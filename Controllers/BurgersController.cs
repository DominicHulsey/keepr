using System;
using System.Collections.Generic;
using burgershack.Models;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BurgersController : Controller
  {
    List<Burger> burgers;
    public BurgersController()
    {
      burgers = new List<Burger>();
      burgers.Add(new Burger("The plain Jane", "Burger on a bun", 7.99m));
      burgers.Add(new Burger("MONSTER", "Quad Pattie with bacon, egg, cheese, and donut buns", 11.99m));
      burgers.Add(new Burger("Bacon n Cheese", "bacon, and, cheese, no burger no bun the way it was ment to be", 1.99m));
    }

    [HttpGet]
    public IEnumerable<Burger> Get()
    {
      return burgers;
    }

    [HttpPost]
    public Burger Post([FromBody] Burger burger)
    {
      if (ModelState.IsValid)
      {
        burger = new Burger(burger.Name, burger.Description, burger.Price);
        burgers.Add(burger);
        return burger;
      }
      throw new Exception("INVALID BURGER");
    }

  }

}