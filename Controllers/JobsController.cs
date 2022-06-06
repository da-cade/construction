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
  public class JobsController : ControllerBase
  {
    private readonly JobsService _js;

    public JobsController(JobsService js)
    {
      _js = js;
    }

    [HttpGet]
    public ActionResult<List<Job>> GetAll()
    {
      try
      {
        List<Job> jobs = _js.GetAll();
        return Ok(jobs);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Job> Get(int id)
    {
      try
      {
        Job jobs = _js.Get(id);
        return Ok(jobs);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job jobData)
    {
      try
      {
        Job job = _js.Create(jobData);
        return Ok(job);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut]
    public ActionResult<Job> Edit([FromBody] Job jobData)
    {
      try
      {
        Job update = _js.Edit(jobData);
        return Ok(update);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpDelete]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        _js.Delete(id);
        return Ok("Deleted Job");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}