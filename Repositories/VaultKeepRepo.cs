using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using System.Collections;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<VaultKeeps> GetAllVaultKeeps(string Id)
    {
      if (Id != null)
      {
        IEnumerable<VaultKeeps> keeps;
        keeps = _db.Query<VaultKeeps>("SELECT * FROM vaultkeeps WHERE userId = @Id");
        return keeps;
      }
      else
      {
        return null;
      }
    }
    internal VaultKeeps AddToVault(VaultKeeps toAdd)
    {
      try
      {
        int Id = _db.ExecuteScalar<int>(@"INSERT INTO vaultkeeps (vaultId, keepId, userId)
      VALUES (@vaultId, @keepId, @userId);
      SELECT LAST_INSERT_ID();
      ", toAdd);
        toAdd.id = Id;
        return toAdd;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public bool Delete(int Id)
    {
      int success = _db.Execute("DELETE FROM vaultkeeps WHERE id=@Id", new { Id });
      return success > 0;
    }
  }
}