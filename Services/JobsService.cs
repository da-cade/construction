using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using construction.Models;
using construction.Repositories;

namespace construction.Services
{
  public class JobsService
  {
    private readonly JobsRepository _repo;
    public JobsService(JobsRepository repo)
    {
      _repo = repo;
    }

    internal List<Job> GetAll()
    {
      List<Job> jobs = _repo.GetAll();
      return jobs;
    }
    internal Job Get(int id)
    {
      Job job = _repo.Get(id);
      return job;
    }

    internal Job Create(Job jobData)
    {
      Job job = _repo.Create(jobData);
      return job;
    }

    internal Job Edit(Job update)
    {
      Job original = Get(update.Id);
      original.Title = update.Title ?? original.Title;
      original.Description = update.Description ?? original.Description;
      original.Rate = update.Rate;
      _repo.Edit(original);
      return original;
    }

    internal void Delete(int id)
    {
      _repo.Delete(id);
    }

  }
}