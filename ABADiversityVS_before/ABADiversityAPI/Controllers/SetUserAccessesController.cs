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
  [Route("api/SetUserAccesses")]
  public class SetUserAccessesController : Controller
  {
    private readonly ABAContext _context;

    public SetUserAccessesController(ABAContext context)
    {
      _context = context;
    }

    // GET: api/SetUserAccesses
    [HttpGet]
    public IEnumerable<SetUserAccess> GetSetUserAccesses()
    {
      return _context.SetUserAccesses;
    }

    // GET: api/SetUserAccesses/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSetUserAccess([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var setUserAccess = await _context.SetUserAccesses.SingleOrDefaultAsync(m => m.user_grp_id == id);

      if (setUserAccess == null)
      {
        return NotFound();
      }

      return Ok(setUserAccess);
    }

    // PUT: api/SetUserAccesses/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSetUserAccess([FromRoute] int id, [FromBody] SetUserAccess setUserAccess)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != setUserAccess.user_grp_id)
      {
        return BadRequest();
      }

      _context.Entry(setUserAccess).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!SetUserAccessExists(id))
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

    // POST: api/SetUserAccesses
    [HttpPost]
    public async Task<IActionResult> PostSetUserAccess([FromBody] SetUserAccess setUserAccess)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.SetUserAccesses.Add(setUserAccess);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetSetUserAccess", new { id = setUserAccess.user_grp_id }, setUserAccess);
    }

    // DELETE: api/SetUserAccesses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSetUserAccess([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var setUserAccess = await _context.SetUserAccesses.SingleOrDefaultAsync(m => m.user_grp_id == id);
      if (setUserAccess == null)
      {
        return NotFound();
      }

      _context.SetUserAccesses.Remove(setUserAccess);
      await _context.SaveChangesAsync();

      return Ok(setUserAccess);
    }

    private bool SetUserAccessExists(int id)
    {
      return _context.SetUserAccesses.Any(e => e.user_grp_id == id);
    }
  }
}
