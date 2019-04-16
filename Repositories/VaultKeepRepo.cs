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

    public IEnumerable<Keep> GetVaultKeeps(int vaultId, string userId)
    {
      return _db.Query<Keep>(@"SELECT * FROM vaultkeeps vk
INNER JOIN keeps k ON k.id = vk.keepId
WHERE(vaultId = @vaultId AND vk.userId = @userId)", new { vaultId, userId });
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