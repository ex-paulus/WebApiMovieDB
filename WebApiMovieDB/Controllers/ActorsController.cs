using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebApiMovieDB.Models;

namespace WebApiMovieDB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly MovieBaseContext _context;
 
        public ActorsController(MovieBaseContext context)
        {
            _context = context;
        }
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actors>>> GetActors()
        {
            return await _context.Actors.ToListAsync();
        }
        
        // GET: api/Actors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actors>> GetActors(int id)
        {
            var actors = await _context.Actors.FindAsync(id);
            return actors ?? (ActionResult<Actors>) NotFound();
        }
 
        // PUT: api/Actors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActors(int id, Actors actors)
        {
            if (id != actors.ActorId) 
                return BadRequest();

            _context.Entry(actors).State = EntityState.Modified;
 
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (ActorExists(id)) throw;
                return NotFound();
            }
 
            return NoContent();
        }
 
        // POST: api/Actors
        [HttpPost]
        public async Task<ActionResult<Actors>> PostActors(Actors actors)
        {
            _context.Actors.Add(actors);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetActors", new { id = actors.ActorId }, actors);
        }
 
        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Actors>> DeleteActors(int id)
        {
            var actors = await _context.Actors.FindAsync(id);
            if (actors == null) return NotFound();
            _context.Actors.Remove(actors);
            await _context.SaveChangesAsync();
            return actors;
        }
 
        private bool ActorExists(int id) => _context.Actors.Any(e => e.ActorId == id);

    }
}
