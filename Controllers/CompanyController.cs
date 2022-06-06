using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using construction.Models;
using construction.Services;
using Microsoft.AspNetCore.Mvc;

namespace construction.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CompanyController : ControllerBase
  {
    private readonly CompaniesService _cs;

    public CompanyController(CompaniesService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<List<Company>> GetAll()
    {
      try
      {
        List<Company> companies = _cs.GetAll();
        return Ok(companies);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Company> Get(int id)
    {
      try
      {
        Company companies = _cs.Get(id);
        return Ok(companies);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Company> Create([FromBody] Company companyData)
    {
      try
      {
        Company company = _cs.Create(companyData);
        return Ok(company);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut]
    public ActionResult<Company> Edit([FromBody] Company companyData)
    {
      try
      {
        Company update = _cs.Edit(companyData);
        return Ok(update);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        _cs.Delete(id);
        return Ok("Deleted successfully");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}