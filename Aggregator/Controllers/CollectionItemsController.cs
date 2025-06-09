using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aggregator.Data;
using Aggregator.Models;

namespace Aggregator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionItemsController : ControllerBase
    {
        private readonly AggregatorContext _context;

        public CollectionItemsController(AggregatorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollectionItem>>> GetItems()
        {
            return await _context.CollectionItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CollectionItem>> GetItem(int id)
        {
            var item = await _context.CollectionItems.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<CollectionItem>> CreateItem(CollectionItem item)
        {
            _context.CollectionItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, CollectionItem item)
        {
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.CollectionItems.FindAsync(id);
            if (item == null) return NotFound();
            _context.CollectionItems.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
