using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMarket.Data;
using ApiMarket.Models;

namespace ApiMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreArticlesController : ControllerBase
    {
        private readonly ApiMarketContext _context;

        public StoreArticlesController(ApiMarketContext context)
        {
            _context = context;
        }

        // GET: api/StoreArticles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreArticle>>> GetStoreArticle()
        {
            if (_context.StoreArticle == null)
            {
                return NotFound();

            }
            return await _context.StoreArticle.ToListAsync();
        }

        // GET: api/StoreArticles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreArticle>> GetStoreArticle(int id)
        {
          if (_context.StoreArticle == null)
          {
              return NotFound();
          }
            var storeArticle = await _context.StoreArticle.FindAsync(id);

            if (storeArticle == null)
            {
                return NotFound();
            }

            return storeArticle;
        }

        // PUT: api/StoreArticles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoreArticle(int id, StoreArticle storeArticle)
        {
            if (id != storeArticle.Id)
            {
                return BadRequest();
            }

            _context.Entry(storeArticle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreArticleExists(id))
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

        // POST: api/StoreArticles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StoreArticle>> PostStoreArticle(StoreArticle storeArticle)
        {
          if (_context.StoreArticle == null)
          {
              return Problem("Entity set 'ApiMarketContext.StoreArticle'  is null.");
          }
            _context.StoreArticle.Add(storeArticle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStoreArticle", new { id = storeArticle.Id }, storeArticle);
        }

        // DELETE: api/StoreArticles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreArticle(int id)
        {
            if (_context.StoreArticle == null)
            {
                return NotFound();
            }
            var storeArticle = await _context.StoreArticle.FindAsync(id);
            if (storeArticle == null)
            {
                return NotFound();
            }

            _context.StoreArticle.Remove(storeArticle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoreArticleExists(int id)
        {
            return (_context.StoreArticle?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
