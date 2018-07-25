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
    [Route("api/PromotionsAssociatePartners")]
    public class PromotionsAssociatePartnersController : Controller
    {
        private readonly ADContext _context;

        public PromotionsAssociatePartnersController(ADContext context)
        {
            _context = context;
        }

        // GET: api/PromotionsAssociatePartners
        [HttpGet]
        public IEnumerable<PromotionsAssociatePartners> GetPromotionsAssociatePartners()
        {
            return _context.PromotionsAssociatePartners;
        }

        // GET: api/PromotionsAssociatePartners/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromotionsAssociatePartners([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var promotionsAssociatePartners = await _context.PromotionsAssociatePartners.SingleOrDefaultAsync(m => m.PromotionsAssociatePartnerID == id);

            if (promotionsAssociatePartners == null)
            {
                return NotFound();
            }

            return Ok(promotionsAssociatePartners);
        }

        // PUT: api/PromotionsAssociatePartners/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromotionsAssociatePartners([FromRoute] Guid id, [FromBody] PromotionsAssociatePartners promotionsAssociatePartners)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promotionsAssociatePartners.PromotionsAssociatePartnerID)
            {
                return BadRequest();
            }

            _context.Entry(promotionsAssociatePartners).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionsAssociatePartnersExists(id))
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

        // POST: api/PromotionsAssociatePartners
        [HttpPost]
        public async Task<IActionResult> PostPromotionsAssociatePartners([FromBody] PromotionsAssociatePartners promotionsAssociatePartners)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PromotionsAssociatePartners.Add(promotionsAssociatePartners);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPromotionsAssociatePartners", new { id = promotionsAssociatePartners.PromotionsAssociatePartnerID }, promotionsAssociatePartners);
        }

        // DELETE: api/PromotionsAssociatePartners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromotionsAssociatePartners([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var promotionsAssociatePartners = await _context.PromotionsAssociatePartners.SingleOrDefaultAsync(m => m.PromotionsAssociatePartnerID == id);
            if (promotionsAssociatePartners == null)
            {
                return NotFound();
            }

            _context.PromotionsAssociatePartners.Remove(promotionsAssociatePartners);
            await _context.SaveChangesAsync();

            return Ok(promotionsAssociatePartners);
        }

        private bool PromotionsAssociatePartnersExists(Guid id)
        {
            return _context.PromotionsAssociatePartners.Any(e => e.PromotionsAssociatePartnerID == id);
        }
    }
}