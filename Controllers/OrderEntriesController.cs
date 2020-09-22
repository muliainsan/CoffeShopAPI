using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeShop.Enties;
using CoffeShop.EntitiesFramework;

namespace CoffeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderEntriesController : ControllerBase
    {
        private readonly CoffeShopDbContext _context;

        public OrderEntriesController(CoffeShopDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderEntry>>> GetOrderEntry()
        {
            return await _context.OrderEntry.ToListAsync();
        }

        // GET: api/OrderEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderEntry>> GetOrderEntry(Guid id)
        {
            var orderEntry = await _context.OrderEntry.FindAsync(id);

            if (orderEntry == null)
            {
                return NotFound();
            }

            return orderEntry;
        }

        // PUT: api/OrderEntries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderEntry(Guid id, OrderEntry orderEntry)
        {
            if (id != orderEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderEntryExists(id))
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

        // POST: api/OrderEntries
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<OrderEntry>> PostOrderEntry(OrderEntry orderEntry)
        {
            _context.OrderEntry.Add(orderEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderEntry", new { id = orderEntry.Id }, orderEntry);
        }

        // DELETE: api/OrderEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderEntry>> DeleteOrderEntry(Guid id)
        {
            var orderEntry = await _context.OrderEntry.FindAsync(id);
            if (orderEntry == null)
            {
                return NotFound();
            }

            _context.OrderEntry.Remove(orderEntry);
            await _context.SaveChangesAsync();

            return orderEntry;
        }

        private bool OrderEntryExists(Guid id)
        {
            return _context.OrderEntry.Any(e => e.Id == id);
        }
    }
}
