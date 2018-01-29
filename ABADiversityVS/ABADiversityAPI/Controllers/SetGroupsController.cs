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
    [Route("api/SetGroups")]
    public class SetGroupsController : Controller
    {
        private readonly ABAContext _context;

        public SetGroupsController(ABAContext context)
        {
            _context = context;
        }

        // GET: api/SetGroups
        [HttpGet]
        public IEnumerable<SetGroup> GetSetGroups()
        {
            return _context.SetGroups;
        }

        // GET: api/SetGroups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSetGroup([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var setGroup = await _context.SetGroups.SingleOrDefaultAsync(m => m.grp_id == id);

            if (setGroup == null)
            {
                return NotFound();
            }

            return Ok(setGroup);
        }

        // PUT: api/SetGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSetGroup([FromRoute] string id, [FromBody] SetGroup setGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != setGroup.grp_id)
            {
                return BadRequest();
            }

            _context.Entry(setGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SetGroupExists(id))
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

        // POST: api/SetGroups
        [HttpPost]
        public async Task<IActionResult> PostSetGroup([FromBody] SetGroup setGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SetGroups.Add(setGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSetGroup", new { id = setGroup.grp_id }, setGroup);
        }

        // DELETE: api/SetGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSetGroup([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var setGroup = await _context.SetGroups.SingleOrDefaultAsync(m => m.grp_id == id);
            if (setGroup == null)
            {
                return NotFound();
            }

            _context.SetGroups.Remove(setGroup);
            await _context.SaveChangesAsync();

            return Ok(setGroup);
        }

        private bool SetGroupExists(string id)
        {
            return _context.SetGroups.Any(e => e.grp_id == id);
        }
    }
}