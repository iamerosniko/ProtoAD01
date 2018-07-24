using ABADiversityAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABADiversityAPI.Controllers
{
  [Produces("application/json")]
  [Route("api/FirmInitiatives")]
  public class FirmInitiativesController : Controller
  {
    private readonly ABAContext _context;

    public FirmInitiativesController(ABAContext context)
    {
      _context = context;
    }

    // GET: api/FirmInitiatives
    [HttpGet]
    public IEnumerable<FirmInitiatives> GetFirmInitiatives()
    {
      return _context.FirmInitiatives;
    }

    // GET: api/FirmInitiatives/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFirmInitiatives([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var firmInitiatives = await _context.FirmInitiatives.SingleOrDefaultAsync(m => m.FirmInitiativeID == id);

      if (firmInitiatives == null)
      {
        return NotFound();
      }

      return Ok(firmInitiatives);
    }

    // PUT: api/FirmInitiatives/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFirmInitiatives([FromRoute] int id, [FromBody] FirmInitiatives firmInitiatives)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != firmInitiatives.FirmInitiativeID)
      {
        return BadRequest();
      }

      _context.Entry(firmInitiatives).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!FirmInitiativesExists(id))
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

    // POST: api/FirmInitiatives
    [HttpPost]
    public async Task<IActionResult> PostFirmInitiatives([FromBody] FirmInitiatives firmInitiatives)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.FirmInitiatives.Add(firmInitiatives);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetFirmInitiatives", new { id = firmInitiatives.FirmInitiativeID }, firmInitiatives);
    }



    // DELETE: api/FirmInitiatives/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFirmInitiatives([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var firmInitiatives = await _context.FirmInitiatives.SingleOrDefaultAsync(m => m.FirmInitiativeID == id);
      if (firmInitiatives == null)
      {
        return NotFound();
      }

      _context.FirmInitiatives.Remove(firmInitiatives);
      await _context.SaveChangesAsync();

      return Ok(firmInitiatives);
    }

    private bool FirmInitiativesExists(int id)
    {
      return _context.FirmInitiatives.Any(e => e.FirmInitiativeID == id);
    }
  }
}
