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
    [Route("api/Certificates1")]
    public class Certificates1Controller : Controller
    {
        private readonly ADContext _context;

        public Certificates1Controller(ADContext context)
        {
            _context = context;
        }

        // GET: api/Certificates1
        [HttpGet]
        public IEnumerable<Certificates> GetCertificates()
        {
            return _context.Certificates;
        }

        // GET: api/Certificates1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCertificates([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var certificates = await _context.Certificates.SingleOrDefaultAsync(m => m.CertificateID == id);

            if (certificates == null)
            {
                return NotFound();
            }

            return Ok(certificates);
        }

        // PUT: api/Certificates1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificates([FromRoute] Guid id, [FromBody] Certificates certificates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != certificates.CertificateID)
            {
                return BadRequest();
            }

            _context.Entry(certificates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificatesExists(id))
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

        // POST: api/Certificates1
        [HttpPost]
        public async Task<IActionResult> PostCertificates([FromBody] Certificates certificates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Certificates.Add(certificates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCertificates", new { id = certificates.CertificateID }, certificates);
        }

        // DELETE: api/Certificates1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificates([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var certificates = await _context.Certificates.SingleOrDefaultAsync(m => m.CertificateID == id);
            if (certificates == null)
            {
                return NotFound();
            }

            _context.Certificates.Remove(certificates);
            await _context.SaveChangesAsync();

            return Ok(certificates);
        }

        private bool CertificatesExists(Guid id)
        {
            return _context.Certificates.Any(e => e.CertificateID == id);
        }
    }
}