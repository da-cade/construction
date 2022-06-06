using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using construction.Models;
using construction.Repositories;

namespace construction.Services
{
  public class CompaniesService
  {
    private readonly CompaniesRepository _repo;
    internal List<Company> GetAll()
    {
      List<Company> companies = _repo.GetAll();
      return companies;
    }

    internal Company Get(int id)
    {
      Company company = _repo.Get(id);
      return company;
    }

    internal Company Create(Company companyData)
    {
      Company company = _repo.Create(companyData);
      return company;
    }

    internal Company Edit(Company update)
    {
      Company original = Get(update.Id);
      original.Name = update.Name ?? original.Name;
      _repo.Edit(original);
      return original;
    }

    internal void Delete(int id)
    {
      _repo.Delete(id);
    }
  }
}