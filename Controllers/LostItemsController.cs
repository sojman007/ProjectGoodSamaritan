﻿using System;
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
    public class LostItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LostItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LostItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LostItem>>> GetLostItems()
        {
            return await _context.LostItems.ToListAsync();
        }

        // GET: api/LostItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LostItem>> GetLostItem(int id)
        {
            var lostItem = await _context.LostItems.FindAsync(id);

            if (lostItem == null)
            {
                return NotFound();
            }

            return lostItem;
        }

        // PUT: api/LostItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLostItem(int id, LostItem lostItem)
        {
            if (id != lostItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(lostItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LostItemExists(id))
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

        // POST: api/LostItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LostItem>> PostLostItem(LostItem lostItem)
        {
            _context.LostItems.Add(lostItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLostItem", new { id = lostItem.Id }, lostItem);
        }

        // DELETE: api/LostItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LostItem>> DeleteLostItem(int id)
        {
            var lostItem = await _context.LostItems.FindAsync(id);
            if (lostItem == null)
            {
                return NotFound();
            }

            _context.LostItems.Remove(lostItem);
            await _context.SaveChangesAsync();

            return lostItem;
        }

        private bool LostItemExists(int id)
        {
            return _context.LostItems.Any(e => e.Id == id);
        }
    }
}
