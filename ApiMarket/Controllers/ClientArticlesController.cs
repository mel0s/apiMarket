using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMarket.Data;
using ApiMarket.Models;
using ApiMarket.Service;

namespace ApiMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientArticlesController : ControllerBase
    {
        private readonly ApiMarketContext _context;

        private readonly IClientArticleService _clientArticleService;


        public ClientArticlesController(ApiMarketContext context, IClientArticleService clientArticleService)
        {
            _context = context;
            _clientArticleService = clientArticleService;
        }

        // GET: api/ClientArticles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientArticle>>> GetClientArticle()
        {
          if (_context.ClientArticle == null)
          {
              return NotFound();
          }
            return await _context.ClientArticle.ToListAsync();
        }


        [HttpGet("byClient/{idClient}")]
        public async Task<ActionResult<List<ClientArticleLabel>>> GetClientArticleByClient(int idClient)
        {
            if (_context.ClientArticle == null)
            {
                return NotFound();
            }
            var clientArticle = await _clientArticleService.GetArticlesByIdClientLabel(idClient);

            if (clientArticle == null)
            {
                return NotFound();
            }

            return clientArticle;
        }


        // GET: api/ClientArticles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientArticle>> GetClientArticle(int id)
        {
          if (_context.ClientArticle == null)
          {
              return NotFound();
          }
            var clientArticle = await _context.ClientArticle.FindAsync(id);

            if (clientArticle == null)
            {
                return NotFound();
            }

            return clientArticle;
        }

        // PUT: api/ClientArticles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientArticle(int id, ClientArticle clientArticle)
        {
            if (id != clientArticle.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientArticle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientArticleExists(id))
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

        // POST: api/ClientArticles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientArticle>> PostClientArticle(ClientArticle clientArticle)
        {
          if (_context.ClientArticle == null)
          {
              return Problem("Entity set 'ApiMarketContext.ClientArticle'  is null.");
          }
            _context.ClientArticle.Add(clientArticle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientArticle", new { id = clientArticle.Id }, clientArticle);
        }

        // DELETE: api/ClientArticles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientArticle(int id)
        {
            if (_context.ClientArticle == null)
            {
                return NotFound();
            }
            var clientArticle = await _context.ClientArticle.FindAsync(id);
            if (clientArticle == null)
            {
                return NotFound();
            }

            _context.ClientArticle.Remove(clientArticle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientArticleExists(int id)
        {
            return (_context.ClientArticle?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
