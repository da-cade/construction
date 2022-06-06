using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using construction.Models;
using construction.Repositories;

namespace construction.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _repo;

    public ContractorsService(ContractorsRepository repo)
    {
      _repo = repo;
    }

    internal List<Contractor> GetAll()
    {
      List<Contractor> contractors = _repo.GetAll();
      return contractors;
    }

    internal Contractor Get(int id)
    {
      Contractor contractor = _repo.Get(id);
      return contractor;
    }

    internal Contractor Create(Contractor contractorData)
    {
      Contractor contractor = _repo.Create(contractorData);
      return contractor;
    }

    internal Contractor Edit(Contractor update)
    {
      Contractor original = Get(update.Id);
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