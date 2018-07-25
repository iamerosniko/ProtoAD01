﻿using System;
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
    [Route("api/ReducedHoursLawyers")]
    public class ReducedHoursLawyersController : Controller
    {
        private readonly ADContext _context;

        public ReducedHoursLawyersController(ADContext context)
        {
            _context = context;
        }

        // GET: api/ReducedHoursLawyers
        [HttpGet]
        public IEnumerable<ReducedHoursLawyers> GetReducedHoursLawyers()
        {
            return _context.ReducedHoursLawyers;
        }

        // GET: api/ReducedHoursLawyers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReducedHoursLawyers([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reducedHoursLawyers = await _context.ReducedHoursLawyers.SingleOrDefaultAsync(m => m.ReducedHoursLawyerID == id);

            if (reducedHoursLawyers == null)
            {
                return NotFound();
            }

            return Ok(reducedHoursLawyers);
        }

        // PUT: api/ReducedHoursLawyers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReducedHoursLawyers([FromRoute] Guid id, [FromBody] ReducedHoursLawyers reducedHoursLawyers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reducedHoursLawyers.ReducedHoursLawyerID)
            {
                return BadRequest();
            }

            _context.Entry(reducedHoursLawyers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReducedHoursLawyersExists(id))
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

        // POST: api/ReducedHoursLawyers
        [HttpPost]
        public async Task<IActionResult> PostReducedHoursLawyers([FromBody] ReducedHoursLawyers reducedHoursLawyers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ReducedHoursLawyers.Add(reducedHoursLawyers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReducedHoursLawyers", new { id = reducedHoursLawyers.ReducedHoursLawyerID }, reducedHoursLawyers);
        }

        // DELETE: api/ReducedHoursLawyers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReducedHoursLawyers([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reducedHoursLawyers = await _context.ReducedHoursLawyers.SingleOrDefaultAsync(m => m.ReducedHoursLawyerID == id);
            if (reducedHoursLawyers == null)
            {
                return NotFound();
            }

            _context.ReducedHoursLawyers.Remove(reducedHoursLawyers);
            await _context.SaveChangesAsync();

            return Ok(reducedHoursLawyers);
        }

        private bool ReducedHoursLawyersExists(Guid id)
        {
            return _context.ReducedHoursLawyers.Any(e => e.ReducedHoursLawyerID == id);
        }
    }
}