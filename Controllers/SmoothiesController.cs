using System;
using System.Collections.Generic;
using burgershack.Models;
using burgershack.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace burgershack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SmoothiesController : Controller
  {
    SmoothiesRepository _repo;

    public SmoothiesController(SmoothiesRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public IEnumerable<Smoothie> Get()
    {
      return _repo.GetAll();
    }

    [HttpPost]
    public Smoothie Post([FromBody] Smoothie smoothie)
    {
      if (ModelState.IsValid)
      {
        smoothie = new Smoothie(smoothie.Name, smoothie.Description, smoothie.Price);
        return _repo.Create(smoothie);
      }
      throw new Exception("INVALID SMOOTHIE");
    }

  }

}