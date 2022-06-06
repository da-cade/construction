using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using construction.Models;
using Dapper;

namespace construction.Repositories
{
  public class CompaniesRepository
  {
    private readonly IDbConnection _db;

    public CompaniesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Company> GetAll()
    {
      string sql = "SELECT * FROM companies";
      return _db.Query<Company>(sql).ToList();
    }

    internal Company Get(int id)
    {
      string sql = "SELECT * FROM companies WHERE id = @id";
      return _db.QueryFirstOrDefault<Company>(sql, new { id });
    }

    internal Company Create(Company companyData)
    {
      string sql = @"
      INSERT INTO companies
      name
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();
      ";
      _db.ExecuteScalar<int>(sql, companyData);
      return companyData;
    }

    internal Company Edit(Company original)
    {
      string sql = @"
      UPDATE companies
      SET
        name = @name
      WHERE id = @Id;
      ";
      _db.Execute(sql, original);
      return original;
    }

    internal void Delete(int id)
    {
      string sql = "REMOVE FROM companies WHERE id = @Id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}