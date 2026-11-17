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
    public class AspNetUserPasskeysController : ControllerBase
    {
        private readonly WebRestOracleContext _context;

        public AspNetUserPasskeysController(WebRestOracleContext context)
        {
            _context = context;
        }

        // GET: api/AspNetUserPasskeys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetUserPasskeys>>> GetAspNetUserPasskeys()
        {
            return await _context.AspNetUserPasskeys.ToListAsync();
        }

        // GET: api/AspNetUserPasskeys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetUserPasskeys>> GetAspNetUserPasskeys(Byte[] id)
        {
            var aspNetUserPasskeys = await _context.AspNetUserPasskeys.FindAsync(id);

            if (aspNetUserPasskeys == null)
            {
                return NotFound();
            }

            return aspNetUserPasskeys;
        }

        // PUT: api/AspNetUserPasskeys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetUserPasskeys([FromRoute] byte[] id, AspNetUserPasskeys aspNetUserPasskeys)
        {
            if (id != aspNetUserPasskeys.CredentialId)
            {
                return BadRequest();
            }

            _context.Entry(aspNetUserPasskeys).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUserPasskeysExists(id))
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

        // POST: api/AspNetUserPasskeys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AspNetUserPasskeys>> PostAspNetUserPasskeys(AspNetUserPasskeys aspNetUserPasskeys)
        {
            _context.AspNetUserPasskeys.Add(aspNetUserPasskeys);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetUserPasskeysExists(aspNetUserPasskeys.CredentialId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAspNetUserPasskeys", new { id = aspNetUserPasskeys.CredentialId }, aspNetUserPasskeys);
        }

        // DELETE: api/AspNetUserPasskeys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspNetUserPasskeys(Byte[] id)
        {
            var aspNetUserPasskeys = await _context.AspNetUserPasskeys.FindAsync(id);
            if (aspNetUserPasskeys == null)
            {
                return NotFound();
            }

            _context.AspNetUserPasskeys.Remove(aspNetUserPasskeys);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AspNetUserPasskeysExists(Byte[] id)
        {
            return _context.AspNetUserPasskeys.Any(e => e.CredentialId == id);
        }
    }
}
