using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectGoodSamaritan.Data;
using ProjectGoodSamaritan.Models;

namespace ProjectGoodSamaritan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoundItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FoundItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FoundItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoundItem>>> GetFoundItems()
        {
            return await _context.FoundItems.ToListAsync();
        }

        // GET: api/FoundItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoundItem>> GetFoundItem(int id)
        {
            var foundItem = await _context.FoundItems.FindAsync(id);

            if (foundItem == null)
            {
                return NotFound();
            }

            return foundItem;
        }

        // PUT: api/FoundItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoundItem(int id, FoundItem foundItem)
        {
            if (id != foundItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(foundItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoundItemExists(id))
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

        // POST: api/FoundItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FoundItem>> PostFoundItem(FoundItem foundItem)
        {
            _context.FoundItems.Add(foundItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoundItem", new { id = foundItem.Id }, foundItem);
        }

        // DELETE: api/FoundItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FoundItem>> DeleteFoundItem(int id)
        {
            var foundItem = await _context.FoundItems.FindAsync(id);
            if (foundItem == null)
            {
                return NotFound();
            }

            _context.FoundItems.Remove(foundItem);
            await _context.SaveChangesAsync();

            return foundItem;
        }

        private bool FoundItemExists(int id)
        {
            return _context.FoundItems.Any(e => e.Id == id);
        }
    }
}
