using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace construction.Models
{
  public class Job
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int ContractorId { get; set; }
    public int CompanyId { get; set; }
    public double Rate { get; set; }
  }
}