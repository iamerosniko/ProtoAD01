using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Tables;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/TopTenHighestCompensations")]
    public class TopTenHighestCompensationsController : Controller
    {
        private readonly ADContext _context;

        public TopTenHighestCompensationsController(ADContext context)
        {
            _context = context;
        }

        // GET: api/TopTenHighestCompensations
        [HttpGet]
        public IEnumerable<TopTenHighestCompensations> GetTopTenHighestCompensations()
        {
            return _context.TopTenHighestCompensations;
        }

        // GET: api/TopTenHighestCompensations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopTenHighestCompensations([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var topTenHighestCompensations = await _context.TopTenHighestCompensations.SingleOrDefaultAsync(m => m.TopTenHighestCompensationID == id);

            if (topTenHighestCompensations == null)
            {
                return NotFound();
            }

            return Ok(topTenHighestCompensations);
        }

        // PUT: api/TopTenHighestCompensations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopTenHighestCompensations([FromRoute] Guid id, [FromBody] TopTenHighestCompensations topTenHighestCompensations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != topTenHighestCompensations.TopTenHighestCompensationID)
            {
                return BadRequest();
            }

            _context.Entry(topTenHighestCompensations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopTenHighestCompensationsExists(id))
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

        // POST: api/TopTenHighestCompensations
        [HttpPost]
        public async Task<IActionResult> PostTopTenHighestCompensations([FromBody] TopTenHighestCompensations topTenHighestCompensations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TopTenHighestCompensations.Add(topTenHighestCompensations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTopTenHighestCompensations", new { id = topTenHighestCompensations.TopTenHighestCompensationID }, topTenHighestCompensations);
        }

        // DELETE: api/TopTenHighestCompensations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopTenHighestCompensations([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var topTenHighestCompensations = await _context.TopTenHighestCompensations.SingleOrDefaultAsync(m => m.TopTenHighestCompensationID == id);
            if (topTenHighestCompensations == null)
            {
                return NotFound();
            }

            _context.TopTenHighestCompensations.Remove(topTenHighestCompensations);
            await _context.SaveChangesAsync();

            return Ok(topTenHighestCompensations);
        }

        private bool TopTenHighestCompensationsExists(Guid id)
        {
            return _context.TopTenHighestCompensations.Any(e => e.TopTenHighestCompensationID == id);
        }
    }
}