using ABADiversityAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABADiversityAPI.Controllers
{
  [Produces("application/json")]
  [Route("api/HomegrownPartners")]
  public class HomegrownPartnersController : Controller
  {
    private readonly ABAContext _context;

    public HomegrownPartnersController(ABAContext context)
    {
      _context = context;
    }

    // GET: api/HomegrownPartners
    [HttpGet]
    public IEnumerable<HomegrownPartners> GetHomegrownPartners()
    {
      return _context.HomegrownPartners;
    }

    // GET: api/HomegrownPartners/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetHomegrownPartners([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var homegrownPartners = await _context.HomegrownPartners.SingleOrDefaultAsync(m => m.HomegrownPartnersID == id);

      if (homegrownPartners == null)
      {
        return NotFound();
      }

      return Ok(homegrownPartners);
    }

    // PUT: api/HomegrownPartners/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHomegrownPartners([FromRoute] int id, [FromBody] HomegrownPartners homegrownPartners)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != homegrownPartners.HomegrownPartnersID)
      {
        return BadRequest();
      }

      _context.Entry(homegrownPartners).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!HomegrownPartnersExists(id))
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

    // POST: api/HomegrownPartners
    [HttpPost]
    public async Task<IActionResult> PostHomegrownPartners([FromBody] HomegrownPartners homegrownPartners)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.HomegrownPartners.Add(homegrownPartners);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetHomegrownPartners", new { id = homegrownPartners.HomegrownPartnersID }, homegrownPartners);
    }

    // DELETE: api/HomegrownPartners/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHomegrownPartners([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var homegrownPartners = await _context.HomegrownPartners.SingleOrDefaultAsync(m => m.HomegrownPartnersID == id);
      if (homegrownPartners == null)
      {
        return NotFound();
      }

      _context.HomegrownPartners.Remove(homegrownPartners);
      await _context.SaveChangesAsync();

      return Ok(homegrownPartners);
    }

    private bool HomegrownPartnersExists(int id)
    {
      return _context.HomegrownPartners.Any(e => e.HomegrownPartnersID == id);
    }
  }
}
