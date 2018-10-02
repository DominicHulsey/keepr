using System.Collections.Generic;
using System.Data;
using System.Linq;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{

  public class SmoothiesRepository
  {
    private IDbConnection _db;

    public SmoothiesRepository(IDbConnection db)
    {
      _db = db;
    }

    //CRUD VIA SQL

    //GET ALL BURGERS
    public IEnumerable<Smoothie> GetAll()
    {
      return _db.Query<Smoothie>("SELECT * FROM smoothies;");
    }

    //GET BURGER BY ID
    public Smoothie GetById(int id)
    {
      return _db.Query<Smoothie>("SELECT * FROM smoothies WHERE id = @id;", new { id }).FirstOrDefault();
    }

    //CREATE BURGER
    public Smoothie Create(Smoothie smoothie)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO smoothies (name, description, price)
        VALUES (@Name, @Description, @Price);
        SELECT LAST_INSERT_ID();", smoothie
      );
      smoothie.Id = id;
      return smoothie;
    }

    //UPDATE smoothie
    public Smoothie Update(Smoothie smoothie)
    {
      _db.Execute(@"
      UPDATE smoothies SET (name, description, price) 
      VALUES (@Name, @Description, @Price)
      WHERE id = @Id
      ", smoothie);
      return smoothie;
    }

    //DELETE smoothie
    public Smoothie Delete(Smoothie smoothie)
    {
      _db.Execute("DELETE FROM smoothies WHERE id = @Id", smoothie);
      return smoothie;
    }

    public int Delete(int id)
    {
      return _db.Execute("DELETE FROM smoothies WHERE id = @id", new { id });
    }


  }

}