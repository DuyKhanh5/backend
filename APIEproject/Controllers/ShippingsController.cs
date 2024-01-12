using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIEproject.Models;

namespace APIEproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingsController : ControllerBase
    {
        private readonly APIEprojectContext _context;

        public ShippingsController(APIEprojectContext context)
        {
            _context = context;
        }

        // GET: api/Shippings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipping>>> GetShippings()
        {
          if (_context.Shippings == null)
          {
              return NotFound();
          }
            return await _context.Shippings.ToListAsync();
        }

        // GET: api/Shippings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipping>> GetShipping(int id)
        {
          if (_context.Shippings == null)
          {
              return NotFound();
          }
            var shipping = await _context.Shippings.FindAsync(id);

            if (shipping == null)
            {
                return NotFound();
            }

            return shipping;
        }

        // PUT: api/Shippings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipping(int id, Shipping shipping)
        {
            if (id != shipping.Id)
            {
                return BadRequest();
            }

            _context.Entry(shipping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingExists(id))
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

        // POST: api/Shippings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shipping>> PostShipping(Shipping shipping)
        {
          if (_context.Shippings == null)
          {
              return Problem("Entity set 'APIEprojectContext.Shippings'  is null.");
          }
            _context.Shippings.Add(shipping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipping", new { id = shipping.Id }, shipping);
        }

        // DELETE: api/Shippings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipping(int id)
        {
            if (_context.Shippings == null)
            {
                return NotFound();
            }
            var shipping = await _context.Shippings.FindAsync(id);
            if (shipping == null)
            {
                return NotFound();
            }

            _context.Shippings.Remove(shipping);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShippingExists(int id)
        {
            return (_context.Shippings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
