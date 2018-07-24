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
    [Route("api/HoursReducedLawyers")]
    public class HoursReducedLawyersController : Controller
    {
        private readonly ABAContext _context;

        public HoursReducedLawyersController(ABAContext context)
        {
            _context = context;
        }

        // GET: api/HoursReducedLawyers
        [HttpGet]
        public IEnumerable<HoursReducedLawyers> GetHoursReducedLawyers()
        {
            return _context.HoursReducedLawyers;
        }

        // GET: api/HoursReducedLawyers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHoursReducedLawyers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hoursReducedLawyers = await _context.HoursReducedLawyers.SingleOrDefaultAsync(m => m.HoursReducedLawyerID == id);

            if (hoursReducedLawyers == null)
            {
                return NotFound();
            }

            return Ok(hoursReducedLawyers);
        }

        // PUT: api/HoursReducedLawyers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoursReducedLawyers([FromRoute] int id, [FromBody] HoursReducedLawyers hoursReducedLawyers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hoursReducedLawyers.HoursReducedLawyerID)
            {
                return BadRequest();
            }

            _context.Entry(hoursReducedLawyers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoursReducedLawyersExists(id))
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

        // POST: api/HoursReducedLawyers
        [HttpPost]
        public async Task<IActionResult> PostHoursReducedLawyers([FromBody] HoursReducedLawyers hoursReducedLawyers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HoursReducedLawyers.Add(hoursReducedLawyers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoursReducedLawyers", new { id = hoursReducedLawyers.HoursReducedLawyerID }, hoursReducedLawyers);
        }

        // DELETE: api/HoursReducedLawyers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoursReducedLawyers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hoursReducedLawyers = await _context.HoursReducedLawyers.SingleOrDefaultAsync(m => m.HoursReducedLawyerID == id);
            if (hoursReducedLawyers == null)
            {
                return NotFound();
            }

            _context.HoursReducedLawyers.Remove(hoursReducedLawyers);
            await _context.SaveChangesAsync();

            return Ok(hoursReducedLawyers);
        }

        private bool HoursReducedLawyersExists(int id)
        {
            return _context.HoursReducedLawyers.Any(e => e.HoursReducedLawyerID == id);
        }
    }
}