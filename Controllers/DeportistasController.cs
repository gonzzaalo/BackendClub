using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClubBackend.DataContext;

namespace ClubBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeportistasController : ControllerBase
    {
        private readonly ClubContext _context;

        public DeportistasController(ClubContext context)
        {
            _context = context;
        }

        // GET: api/Deportistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deportista>>> GetDeportistas()
        {
            return await _context.Deportistas
                                 .Include(d => d.Deporte)
                                 .Include(d => d.Cuota)
                                 .ToListAsync();
        }

        // GET: api/Deportistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deportista>> GetDeportista(int id)
        {
            var deportista = await _context.Deportistas
                                            .Include(d => d.Deporte)
                                            .Include(d => d.Cuota)
                                            .FirstOrDefaultAsync(d => d.Id == id);

            if (deportista == null)
            {
                return NotFound();
            }

            return deportista;
        }

        // PUT: api/Deportistas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeportista(int id, Deportista deportista)
        {
            if (id != deportista.Id)
            {
                return BadRequest();
            }

            _context.Entry(deportista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeportistaExists(id))
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

        // POST: api/Deportistas
        [HttpPost]
        public async Task<ActionResult<Deportista>> PostDeportista(Deportista deportista)
        {
            _context.Deportistas.Add(deportista);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDeportista), new { id = deportista.Id }, deportista);
        }

        // DELETE: api/Deportistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeportista(int id)
        {
            var deportista = await _context.Deportistas.FindAsync(id);
            if (deportista == null)
            {
                return NotFound();
            }

            _context.Deportistas.Remove(deportista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeportistaExists(int id)
        {
            return _context.Deportistas.Any(e => e.Id == id);
        }
    }
}
