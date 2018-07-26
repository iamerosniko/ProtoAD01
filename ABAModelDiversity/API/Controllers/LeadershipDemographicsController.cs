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
    [Route("api/LeadershipDemographics")]
    public class LeadershipDemographicsController : Controller
    {
        private readonly ADContext _context;

        public LeadershipDemographicsController(ADContext context)
        {
            _context = context;
        }

        // GET: api/LeadershipDemographics
        [HttpGet]
        public IEnumerable<LeadershipDemographics> GetLeadershipDemographics()
        {
            return _context.LeadershipDemographics;
        }

        // GET: api/LeadershipDemographics/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeadershipDemographics([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leadershipDemographics = await _context.LeadershipDemographics.SingleOrDefaultAsync(m => m.LeadershipDemographicID == id);

            if (leadershipDemographics == null)
            {
                return NotFound();
            }

            return Ok(leadershipDemographics);
        }

        // PUT: api/LeadershipDemographics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeadershipDemographics([FromRoute] int id, [FromBody] LeadershipDemographics leadershipDemographics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leadershipDemographics.LeadershipDemographicID)
            {
                return BadRequest();
            }

            _context.Entry(leadershipDemographics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadershipDemographicsExists(id))
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

        // POST: api/LeadershipDemographics
        [HttpPost]
        public async Task<IActionResult> PostLeadershipDemographics([FromBody] LeadershipDemographics leadershipDemographics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LeadershipDemographics.Add(leadershipDemographics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLeadershipDemographics", new { id = leadershipDemographics.LeadershipDemographicID }, leadershipDemographics);
        }

        // DELETE: api/LeadershipDemographics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeadershipDemographics([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var leadershipDemographics = await _context.LeadershipDemographics.SingleOrDefaultAsync(m => m.LeadershipDemographicID == id);
            if (leadershipDemographics == null)
            {
                return NotFound();
            }

            _context.LeadershipDemographics.Remove(leadershipDemographics);
            await _context.SaveChangesAsync();

            return Ok(leadershipDemographics);
        }

        private bool LeadershipDemographicsExists(int id)
        {
            return _context.LeadershipDemographics.Any(e => e.LeadershipDemographicID == id);
        }
    }
}