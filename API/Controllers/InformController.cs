using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models.db;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformController : ControllerBase
    {
        private readonly HousingEstateContext _context;

        public InformController(HousingEstateContext context)
        {
            _context = context;
        }

        // GET: api/Inform
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Information>>> GetInformation()
        {
            return await _context.Information.ToListAsync();
        }

        // GET: api/Inform/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Information>> GetInformation(string id)
        {
            var information = await _context.Information.FindAsync(id);

            if (information == null)
            {
                return NotFound();
            }

            return information;
        }

        // PUT: api/Inform/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInformation(string id, Information information)
        {
            if (id != information.IdNumber)
            {
                return BadRequest();
            }

            _context.Entry(information).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformationExists(id))
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

        // POST: api/Inform
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Information>> PostInformation(Information information)
        {
            _context.Information.Add(information);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InformationExists(information.IdNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInformation", new { id = information.IdNumber }, information);
        }

        // DELETE: api/Inform/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Information>> DeleteInformation(string id)
        {
            var information = await _context.Information.FindAsync(id);
            if (information == null)
            {
                return NotFound();
            }

            _context.Information.Remove(information);
            await _context.SaveChangesAsync();

            return information;
        }

        private bool InformationExists(string id)
        {
            return _context.Information.Any(e => e.IdNumber == id);
        }
    }
}
