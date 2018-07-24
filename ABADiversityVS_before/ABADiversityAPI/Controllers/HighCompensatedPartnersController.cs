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
    [Route("api/HighCompensatedPartners")]
    public class HighCompensatedPartnersController : Controller
    {
        private readonly ABAContext _context;

        public HighCompensatedPartnersController(ABAContext context)
        {
            _context = context;
        }

        // GET: api/HighCompensatedPartners
        [HttpGet]
        public IEnumerable<HighCompensatedPartners> GetHighCompensatedPartners()
        {
            return _context.HighCompensatedPartners;
        }

        // GET: api/HighCompensatedPartners/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHighCompensatedPartners([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var highCompensatedPartners = await _context.HighCompensatedPartners.SingleOrDefaultAsync(m => m.HighCompensatedPartnerID == id);

            if (highCompensatedPartners == null)
            {
                return NotFound();
            }

            return Ok(highCompensatedPartners);
        }

        // PUT: api/HighCompensatedPartners/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHighCompensatedPartners([FromRoute] int id, [FromBody] HighCompensatedPartners highCompensatedPartners)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != highCompensatedPartners.HighCompensatedPartnerID)
            {
                return BadRequest();
            }

            _context.Entry(highCompensatedPartners).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HighCompensatedPartnersExists(id))
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

        // POST: api/HighCompensatedPartners
        [HttpPost]
        public async Task<IActionResult> PostHighCompensatedPartners([FromBody] HighCompensatedPartners highCompensatedPartners)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HighCompensatedPartners.Add(highCompensatedPartners);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHighCompensatedPartners", new { id = highCompensatedPartners.HighCompensatedPartnerID }, highCompensatedPartners);
        }

        // DELETE: api/HighCompensatedPartners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHighCompensatedPartners([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var highCompensatedPartners = await _context.HighCompensatedPartners.SingleOrDefaultAsync(m => m.HighCompensatedPartnerID == id);
            if (highCompensatedPartners == null)
            {
                return NotFound();
            }

            _context.HighCompensatedPartners.Remove(highCompensatedPartners);
            await _context.SaveChangesAsync();

            return Ok(highCompensatedPartners);
        }

        private bool HighCompensatedPartnersExists(int id)
        {
            return _context.HighCompensatedPartners.Any(e => e.HighCompensatedPartnerID == id);
        }
    }
}