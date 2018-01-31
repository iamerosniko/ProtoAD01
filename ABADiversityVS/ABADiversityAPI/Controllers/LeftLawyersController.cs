using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ABADiversityAPI.Entities;

namespace ABADiversityAPI.Controllers
{
  [Produces("application/json")]
  [Route("api/LeftLawyers")]
  public class LeftLawyersController : Controller
  {
    private readonly ABAContext _context;

    public LeftLawyersController(ABAContext context)
    {
      _context = context;
    }

    // GET: api/LeftLawyers
    [HttpGet]
    public IEnumerable<LeftLawyers> GetLeftLawyers()
    {
      return _context.LeftLawyers;
    }

    // GET: api/LeftLawyers/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLeftLawyers([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var leftLawyers = await _context.LeftLawyers.SingleOrDefaultAsync(m => m.LeftLawyerID == id);

      if (leftLawyers == null)
      {
        return NotFound();
      }

      return Ok(leftLawyers);
    }

    // PUT: api/LeftLawyers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLeftLawyers([FromRoute] int id, [FromBody] LeftLawyers leftLawyers)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != leftLawyers.LeftLawyerID)
      {
        return BadRequest();
      }

      _context.Entry(leftLawyers).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!LeftLawyersExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/LeftLawyers
    [HttpPost]
    public async Task<IActionResult> PostLeftLawyers([FromBody] LeftLawyers leftLawyers)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.LeftLawyers.Add(leftLawyers);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetLeftLawyers", new { id = leftLawyers.LeftLawyerID }, leftLawyers);
    }

    // DELETE: api/LeftLawyers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLeftLawyers([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var leftLawyers = await _context.LeftLawyers.SingleOrDefaultAsync(m => m.LeftLawyerID == id);
      if (leftLawyers == null)
      {
        return NotFound();
      }

      _context.LeftLawyers.Remove(leftLawyers);
      await _context.SaveChangesAsync();

      return Ok(leftLawyers);
    }

    private bool LeftLawyersExists(int id)
    {
      return _context.LeftLawyers.Any(e => e.LeftLawyerID == id);
    }
  }
}
