using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using construction.Models;
using Dapper;

namespace construction.Repositories
{
  public class ContractorsRepository
  {
    private readonly IDbConnection _db;

    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Contractor> GetAll()
    {
      string sql = "SELECT * FROM contractors";
      return _db.Query<Contractor>(sql).ToList();
    }

    internal Contractor Get(int id)
    {
      string sql = "SELECT * FROM contractors WHERE id = @id";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }

    internal Contractor Create(Contractor contractorData)
    {
      string sql = @"
      INSERT INTO contractors
      name
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();
      ";
      _db.ExecuteScalar<int>(sql, contractorData);
      return contractorData;
    }

    internal Contractor Edit(Contractor original)
    {
      string sql = @"
      UPDATE contractors
      SET
        name = @name,
      WHERE id = @Id;
      ";
      _db.Execute(sql, original);
      return original;
    }

    internal void Delete(int id)
    {
      string sql = "REMOVE FROM contractors WHERE id = @Id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}
