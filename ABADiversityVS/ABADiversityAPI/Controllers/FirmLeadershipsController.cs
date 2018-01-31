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
    [Route("api/FirmLeaderships")]
    public class FirmLeadershipsController : Controller
    {
        private readonly ABAContext _context;

        public FirmLeadershipsController(ABAContext context)
        {
            _context = context;
        }

        // GET: api/FirmLeaderships
        [HttpGet]
        public IEnumerable<FirmLeaderships> GetFirmLeaderships()
        {
            return _context.FirmLeaderships;
        }

        // GET: api/FirmLeaderships/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFirmLeaderships([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var firmLeaderships = await _context.FirmLeaderships.SingleOrDefaultAsync(m => m.FirmLeadershipID == id);

            if (firmLeaderships == null)
            {
                return NotFound();
            }

            return Ok(firmLeaderships);
        }

        // PUT: api/FirmLeaderships/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFirmLeaderships([FromRoute] int id, [FromBody] FirmLeaderships firmLeaderships)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != firmLeaderships.FirmLeadershipID)
            {
                return BadRequest();
            }

            _context.Entry(firmLeaderships).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirmLeadershipsExists(id))
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

        // POST: api/FirmLeaderships
        [HttpPost]
        public async Task<IActionResult> PostFirmLeaderships([FromBody] FirmLeaderships firmLeaderships)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FirmLeaderships.Add(firmLeaderships);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFirmLeaderships", new { id = firmLeaderships.FirmLeadershipID }, firmLeaderships);
        }

        // DELETE: api/FirmLeaderships/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFirmLeaderships([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var firmLeaderships = await _context.FirmLeaderships.SingleOrDefaultAsync(m => m.FirmLeadershipID == id);
            if (firmLeaderships == null)
            {
                return NotFound();
            }

            _context.FirmLeaderships.Remove(firmLeaderships);
            await _context.SaveChangesAsync();

            return Ok(firmLeaderships);
        }

        private bool FirmLeadershipsExists(int id)
        {
            return _context.FirmLeaderships.Any(e => e.FirmLeadershipID == id);
        }
    }
}