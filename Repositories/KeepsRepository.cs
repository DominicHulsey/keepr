using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using System.Collections;

namespace keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetAllKeeps()
    {
      return _db.Query<Keep>("SELECT * FROM keeps");
    }

    internal Keep GetById(int Id)
    {
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM players WHERE id = @Id", new { Id });
    }

    public Keep CreateKeep(Keep keep)
    {
      try
      {
        int Id = _db.ExecuteScalar<int>(@"
          INSERT INTO keeps (title, img)
          VALUES (@title, @img);
          SELECT LAST_INSERT_ID();
          ", keep);
        keep.id = Id;
        return keep;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public bool Delete(int Id)
    {
      int success = _db.Execute("DELETE FROM keeps WHERE id=@Id", new { Id });
      return success > 0;
    }
  }
}