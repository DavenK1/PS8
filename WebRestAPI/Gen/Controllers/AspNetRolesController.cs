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
    public class AspNetRolesController : ControllerBase
    {
        private readonly WebRestOracleContext _context;

        public AspNetRolesController(WebRestOracleContext context)
        {
            _context = context;
        }

        // GET: api/AspNetRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetRoles>>> GetAspNetRoles()
        {
            return await _context.AspNetRoles.ToListAsync();
        }

        // GET: api/AspNetRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetRoles>> GetAspNetRoles(string id)
        {
            var aspNetRoles = await _context.AspNetRoles.FindAsync(id);

            if (aspNetRoles == null)
            {
                return NotFound();
            }

            return aspNetRoles;
        }

        // PUT: api/AspNetRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAspNetRoles(string id, AspNetRoles aspNetRoles)
        {
            if (id != aspNetRoles.Id)
            {
                return BadRequest();
            }

            _context.Entry(aspNetRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetRolesExists(id))
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

        // POST: api/AspNetRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AspNetRoles>> PostAspNetRoles(AspNetRoles aspNetRoles)
        {
            _context.AspNetRoles.Add(aspNetRoles);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AspNetRolesExists(aspNetRoles.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAspNetRoles", new { id = aspNetRoles.Id }, aspNetRoles);
        }

        // DELETE: api/AspNetRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAspNetRoles(string id)
        {
            var aspNetRoles = await _context.AspNetRoles.FindAsync(id);
            if (aspNetRoles == null)
            {
                return NotFound();
            }

            _context.AspNetRoles.Remove(aspNetRoles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AspNetRolesExists(string id)
        {
            return _context.AspNetRoles.Any(e => e.Id == id);
        }
    }
}
