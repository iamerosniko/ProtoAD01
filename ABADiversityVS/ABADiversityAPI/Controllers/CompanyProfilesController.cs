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
    [Route("api/CompanyProfiles")]
    public class CompanyProfilesController : Controller
    {
        private readonly ABAContext _context;

        public CompanyProfilesController(ABAContext context)
        {
            _context = context;
        }

        // GET: api/CompanyProfiles
        [HttpGet]
        public IEnumerable<CompanyProfiles> GetCompanyProfiles()
        {
            return _context.CompanyProfiles;
        }

        // GET: api/CompanyProfiles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyProfiles([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companyProfiles = await _context.CompanyProfiles.SingleOrDefaultAsync(m => m.CompanyProfileID == id);

            if (companyProfiles == null)
            {
                return NotFound();
            }

            return Ok(companyProfiles);
        }

        // PUT: api/CompanyProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyProfiles([FromRoute] int id, [FromBody] CompanyProfiles companyProfiles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyProfiles.CompanyProfileID)
            {
                return BadRequest();
            }

            _context.Entry(companyProfiles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyProfilesExists(id))
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

        // POST: api/CompanyProfiles
        [HttpPost]
        public async Task<IActionResult> PostCompanyProfiles([FromBody] CompanyProfiles companyProfiles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CompanyProfiles.Add(companyProfiles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyProfiles", new { id = companyProfiles.CompanyProfileID }, companyProfiles);
        }

        // DELETE: api/CompanyProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyProfiles([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companyProfiles = await _context.CompanyProfiles.SingleOrDefaultAsync(m => m.CompanyProfileID == id);
            if (companyProfiles == null)
            {
                return NotFound();
            }

            _context.CompanyProfiles.Remove(companyProfiles);
            await _context.SaveChangesAsync();

            return Ok(companyProfiles);
        }

        private bool CompanyProfilesExists(int id)
        {
            return _context.CompanyProfiles.Any(e => e.CompanyProfileID == id);
        }
    }
}