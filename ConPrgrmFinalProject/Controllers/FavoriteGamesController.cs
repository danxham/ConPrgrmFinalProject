using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConPrgrmFinalProject.Data;
using ConPrgrmFinalProject.Models;

namespace ConPrgrmFinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteGamesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FavoriteGamesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteGame>>> Get(int? id)
        {
            if (id == null || id == 0)
                return await _context.FavoriteGames.Take(5).ToListAsync();

            var game = await _context.FavoriteGames.FindAsync(id);
            if (game == null) return NotFound();

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<FavoriteGame>> Post(FavoriteGame game)
        {
            _context.FavoriteGames.Add(game);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, FavoriteGame game)
        {
            if (id != game.Id) return BadRequest();

            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _context.FavoriteGames.FindAsync(id);
            if (game == null) return NotFound();

            _context.FavoriteGames.Remove(game);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
