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
    [Route("api/FirmDemographics")]
    public class FirmDemographicsController : Controller
    {
        private readonly ABAContext _context;

        public FirmDemographicsController(ABAContext context)
        {
            _context = context;
        }

        // GET: api/FirmDemographics
        [HttpGet]
        public IEnumerable<FirmDemographics> GetFirmDemographics()
        {
            return _context.FirmDemographics;
        }

        // GET: api/FirmDemographics/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFirmDemographics([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var firmDemographics = await _context.FirmDemographics.SingleOrDefaultAsync(m => m.FIrmDemographicsID == id);

            if (firmDemographics == null)
            {
                return NotFound();
            }

            return Ok(firmDemographics);
        }

        // PUT: api/FirmDemographics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFirmDemographics([FromRoute] int id, [FromBody] FirmDemographics firmDemographics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != firmDemographics.FIrmDemographicsID)
            {
                return BadRequest();
            }

            _context.Entry(firmDemographics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirmDemographicsExists(id))
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

        // POST: api/FirmDemographics
        [HttpPost]
        public async Task<IActionResult> PostFirmDemographics([FromBody] FirmDemographics firmDemographics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FirmDemographics.Add(firmDemographics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFirmDemographics", new { id = firmDemographics.FIrmDemographicsID }, firmDemographics);
        }

        // DELETE: api/FirmDemographics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFirmDemographics([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var firmDemographics = await _context.FirmDemographics.SingleOrDefaultAsync(m => m.FIrmDemographicsID == id);
            if (firmDemographics == null)
            {
                return NotFound();
            }

            _context.FirmDemographics.Remove(firmDemographics);
            await _context.SaveChangesAsync();

            return Ok(firmDemographics);
        }

        private bool FirmDemographicsExists(int id)
        {
            return _context.FirmDemographics.Any(e => e.FIrmDemographicsID == id);
        }
    }
}