using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConPrgrmFinalProject.Data;
using ConPrgrmFinalProject.Models;

namespace ConPrgrmFinalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetInfosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PetInfosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PetInfos or api/PetInfos/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetInfo>>> Get(int? id)
        {
            if (id == null || id == 0)
                return await _context.PetInfos.Take(5).ToListAsync();

            var pet = await _context.PetInfos.FindAsync(id);
            if (pet == null) return NotFound();

            return Ok(pet);
        }

        // POST: api/PetInfos
        [HttpPost]
        public async Task<ActionResult<PetInfo>> Post(PetInfo pet)
        {
            _context.PetInfos.Add(pet);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = pet.Id }, pet);
        }

        // PUT: api/PetInfos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PetInfo pet)
        {
            if (id != pet.Id) return BadRequest();

            _context.Entry(pet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/PetInfos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pet = await _context.PetInfos.FindAsync(id);
            if (pet == null) return NotFound();

            _context.PetInfos.Remove(pet);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
