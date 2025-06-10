using Aggregator.Data;
using Aggregator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aggregator.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionItemsController : ControllerBase
    {
        private readonly AggregatorContext _context;
        private readonly UserManager<AppUser> _userManager;
        private string GetUserId()
        {
            return _userManager.GetUserId(User)!;
        }

        public CollectionItemsController(AggregatorContext context, UserManager<AppUser> UserManager)
        {
            _context = context;
            _userManager = UserManager;
        }

        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollectionItem>>> GetItems()
        {
            var userId = GetUserId();
            return await _context.CollectionItems
                .Where(ci => ci.UserId == userId)
                .ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CollectionItem>> GetItem(int id)
        {
            var item = await _context.CollectionItems.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        [HttpPost]
        public async Task<ActionResult<CollectionItem>> CreateItem(CollectionItem item)
        {
            var userId = GetUserId();
            item.UserId = userId;

            _context.CollectionItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, CollectionItem item)
        {
            if (item.UserId != GetUserId())
                return Forbid();
            if (id != item.Id) return BadRequest();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.CollectionItems.FindAsync(id);
            if (item.UserId != GetUserId())
                return Forbid();
            if (item == null) return NotFound();
            _context.CollectionItems.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
