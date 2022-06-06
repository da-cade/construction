using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using construction.Models;
using Dapper;

namespace construction.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Job> GetAll()
    {
      string sql = @"SELECT 
      j.*, ctr.*, cpy.* 
      FROM jobs j
      JOIN contractors ctr ON j.contractorId = ctr.id 
      JOIN companies cpy ON j.companyId = cpy.id 
      ";
      return _db.Query<Job>(sql).ToList();
    }

    internal Job Get(int id)
    {
      string sql = @"
      SELECT 
      j.*, ctr.*, cpy.* 
      FROM jobs j
      JOIN contractors ctr ON j.contractorId = ctr.id 
      JOIN companies cpy ON j.companyId = cpy.id
      WHERE id = @id";
      return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }

    internal Job Create(Job jobData)
    {
      string sql = @"
      INSERT INTO jobs
      title, description, contractorId, companyId, rate
      VALUES
      (@Title, @Description, @ContractorId, @CompanyId, @Rate);
      SELECT LAST_INSERT_ID();
      ";
      _db.ExecuteScalar<int>(sql, jobData);
      return jobData;
    }

    internal Job Edit(Job original)
    {
      string sql = @"
      UPDATE jobs
      SET
        title = @title,
        description = @description,
        rate= @rate
      WHERE id = @Id;
      ";
      _db.Execute(sql, original);
      return original;
    }

    internal void Delete(int id)
    {
      string sql = "REMOVE FROM jobs WHERE id = @Id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}