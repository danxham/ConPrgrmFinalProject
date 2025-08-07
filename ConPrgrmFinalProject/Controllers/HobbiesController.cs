using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConPrgrmFinalProject.Data;
using ConPrgrmFinalProject.Models;

namespace ConPrgrmFinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HobbiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HobbiesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hobby>>> Get(int? id)
        {
            if (id == null || id == 0)
                return await _context.Hobbies.Take(5).ToListAsync();

            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null) return NotFound();

            return Ok(hobby);
        }

        [HttpPost]
        public async Task<ActionResult<Hobby>> Post(Hobby hobby)
        {
            _context.Hobbies.Add(hobby);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = hobby.Id }, hobby);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Hobby hobby)
        {
            if (id != hobby.Id) return BadRequest();

            _context.Entry(hobby).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null) return NotFound();

            _context.Hobbies.Remove(hobby);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
