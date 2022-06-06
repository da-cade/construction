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
  public class ContractorsController : ControllerBase
  {
    private readonly ContractorsService _cs;

    public ContractorsController(ContractorsService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<List<Contractor>> GetAll()
    {
      try
      {
        List<Contractor> contractors = _cs.GetAll();
        return Ok(contractors);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Contractor> Get(int id)
    {
      try
      {
        Contractor contractors = _cs.Get(id);
        return Ok(contractors);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Contractor> Create([FromBody] Contractor contractorData)
    {
      try
      {
        Contractor contractor = _cs.Create(contractorData);
        return Ok(contractor);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut]
    public ActionResult<Contractor> Edit([FromBody] Contractor contractorData)
    {
      try
      {
        Contractor update = _cs.Edit(contractorData);
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
        return Ok("Deleted Successfully");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}