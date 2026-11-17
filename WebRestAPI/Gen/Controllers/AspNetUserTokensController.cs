using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebRest.EF.Data;
using WebRest.EF.Models;

namespace gen.WebRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetUserTokensController : ControllerBase
    {
        private readonly WebRestOracleContext _context;

        public AspNetUserTokensController(WebRestOracleContext context)
        {
            _context = context;
        }

        // GET: api/AspNetUserTokens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetUserTokens>>> GetAspNetUserTokens()
        {
            return await _context.AspNetUserTokens.ToListAsync();
        }

        // GET: api/AspNetUserTokens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetUserTokens>> GetAspNetUserTokens(string id)
        {
            var aspNetUserTokens = await _context.AspNetUserTokens.FindAsync(id);

            if (aspNetUserTokens == null)
            {
                return NotFound();
            }

            return aspNetUserTokens;
        }

        // PUT: api/AspNetUserTokens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUserTokens(string id, AspNetUserTokens aspNetUserTokens)
        {
            if (id != aspNetUserTokens.UserId)
            {
                return BadRequest();
            }

            _context.Entry(aspNetUserTokens).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUserTokensExists(id))
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

        // POST: api/AspNetUserTokens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AspNetUserTokens>> PostAspNetUserTokens(AspNetUserTokens aspNetUserTokens)
        {
            _context.AspNetUserTokens.Add(aspNetUserTokens);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetUserTokensExists(aspNetUserTokens.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAspNetUserTokens", new { id = aspNetUserTokens.UserId }, aspNetUserTokens);
        }

        // DELETE: api/AspNetUserTokens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspNetUserTokens(string id)
        {
            var aspNetUserTokens = await _context.AspNetUserTokens.FindAsync(id);
            if (aspNetUserTokens == null)
            {
                return NotFound();
            }

            _context.AspNetUserTokens.Remove(aspNetUserTokens);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AspNetUserTokensExists(string id)
        {
            return _context.AspNetUserTokens.Any(e => e.UserId == id);
        }
    }
}
