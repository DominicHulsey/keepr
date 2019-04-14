using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using System.Collections;

namespace keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Vault> GetAllVaults()
    {
      return _db.Query<Vault>("SELECT * FROM vaults");
    }

    internal Vault GetById(int Id)
    {
      return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id = @Id", new { Id });
    }

    public VaultKeeps AddToVault(VaultKeeps toAdd)
    {
      int Id = _db.ExecuteScalar<int>(@"INSERT INTO vaultkeeps (vaultId, keepId, userId)
      VALUES (@vaultId, @keepId, @userId);
      SELECT LAST_INSERT_ID();
      ", toAdd);
      toAdd.id = Id;
      return toAdd;
    }

    public Vault CreateVault(Vault vault)
    {
      try
      {
        int Id = _db.ExecuteScalar<int>(@"
          INSERT INTO vaults (name, description, userId)
          VALUES (@name, @description, @userId);
          SELECT LAST_INSERT_ID();
          ", vault);
        vault.id = Id;
        return vault;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public bool Delete(int Id)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id=@Id", new { Id });
      return success > 0;
    }
  }
}