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
    [Route("api/InitiativeQuestions")]
    public class InitiativeQuestionsController : Controller
    {
        private readonly ABAContext _context;

        public InitiativeQuestionsController(ABAContext context)
        {
            _context = context;
        }

        // GET: api/InitiativeQuestions
        [HttpGet]
        public IEnumerable<InitiativeQuestions> GetInitiativeQuestions()
        {
            return _context.InitiativeQuestions;
        }

        // GET: api/InitiativeQuestions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInitiativeQuestions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var initiativeQuestions = await _context.InitiativeQuestions.SingleOrDefaultAsync(m => m.InitiativeQuestionID == id);

            if (initiativeQuestions == null)
            {
                return NotFound();
            }

            return Ok(initiativeQuestions);
        }

        // PUT: api/InitiativeQuestions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInitiativeQuestions([FromRoute] int id, [FromBody] InitiativeQuestions initiativeQuestions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != initiativeQuestions.InitiativeQuestionID)
            {
                return BadRequest();
            }

            _context.Entry(initiativeQuestions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InitiativeQuestionsExists(id))
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

        // POST: api/InitiativeQuestions
        [HttpPost]
        public async Task<IActionResult> PostInitiativeQuestions([FromBody] InitiativeQuestions initiativeQuestions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InitiativeQuestions.Add(initiativeQuestions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInitiativeQuestions", new { id = initiativeQuestions.InitiativeQuestionID }, initiativeQuestions);
        }

        // DELETE: api/InitiativeQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInitiativeQuestions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var initiativeQuestions = await _context.InitiativeQuestions.SingleOrDefaultAsync(m => m.InitiativeQuestionID == id);
            if (initiativeQuestions == null)
            {
                return NotFound();
            }

            _context.InitiativeQuestions.Remove(initiativeQuestions);
            await _context.SaveChangesAsync();

            return Ok(initiativeQuestions);
        }

        private bool InitiativeQuestionsExists(int id)
        {
            return _context.InitiativeQuestions.Any(e => e.InitiativeQuestionID == id);
        }
    }
}