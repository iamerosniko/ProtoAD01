using ABADiversityAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABADiversityAPI.Controllers
{
  [Produces("application/json")]
  [Route("api/SizeCategories")]
  public class SizeCategoriesController : Controller
  {
    private readonly ABAContext _context;

    public SizeCategoriesController(ABAContext context)
    {
      _context = context;
    }

    // GET: api/SizeCategories
    [HttpGet]
    public IEnumerable<SizeCategory> GetLeftLawSizeCategoryyers()
    {
      return _context.LeftLawSizeCategoryyers;
    }

    // GET: api/SizeCategories/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSizeCategory([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var sizeCategory = await _context.LeftLawSizeCategoryyers.SingleOrDefaultAsync(m => m.SizeCategoryID == id);

      if (sizeCategory == null)
      {
        return NotFound();
      }

      return Ok(sizeCategory);
    }

    // PUT: api/SizeCategories/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSizeCategory([FromRoute] int id, [FromBody] SizeCategory sizeCategory)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != sizeCategory.SizeCategoryID)
      {
        return BadRequest();
      }

      _context.Entry(sizeCategory).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!SizeCategoryExists(id))
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

    // POST: api/SizeCategories
    [HttpPost]
    public async Task<IActionResult> PostSizeCategory([FromBody] SizeCategory sizeCategory)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.LeftLawSizeCategoryyers.Add(sizeCategory);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetSizeCategory", new { id = sizeCategory.SizeCategoryID }, sizeCategory);
    }

    // DELETE: api/SizeCategories/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSizeCategory([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var sizeCategory = await _context.LeftLawSizeCategoryyers.SingleOrDefaultAsync(m => m.SizeCategoryID == id);
      if (sizeCategory == null)
      {
        return NotFound();
      }

      _context.LeftLawSizeCategoryyers.Remove(sizeCategory);
      await _context.SaveChangesAsync();

      return Ok(sizeCategory);
    }

    private bool SizeCategoryExists(int id)
    {
      return _context.LeftLawSizeCategoryyers.Any(e => e.SizeCategoryID == id);
    }
  }
}
