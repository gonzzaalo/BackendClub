using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CLubBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeportesController : ControllerBase
    {
        private readonly ClubContext _context;

        public DeportesController(ClubContext context)
        {
            _context = context;
        }

        // GET: api/Deportes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deporte>>> GetDeportes()
        {
            // Incluir la relación con Profesor
            return await _context.Deportes
                .Include(d => d.Profesor) // Carga ansiosa de la relación con Profesor
                .ToListAsync();
        }

        // GET: api/Deportes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deporte>> GetDeporte(int id)
        {
            // Incluir la relación con Profesor
            var deporte = await _context.Deportes
                .Include(d => d.Profesor) // Carga ansiosa de la relación con Profesor
                .FirstOrDefaultAsync(d => d.Id == id);

            if (deporte == null)
            {
                return NotFound();
            }

            return deporte;
        }

        // PUT: api/Deportes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeporte(int id, Deporte deporte)
        {
            if (id != deporte.Id)
            {
                return BadRequest();
            }

            _context.Entry(deporte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeporteExists(id))
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

        // POST: api/Deportes
        [HttpPost]
        public async Task<ActionResult<Deporte>> PostDeporte(Deporte deporte)
        {
            _context.Deportes.Add(deporte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeporte", new { id = deporte.Id }, deporte);
        }

        // DELETE: api/Deportes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeporte(int id)
        {
            var deporte = await _context.Deportes.FindAsync(id);
            if (deporte == null)
            {
                return NotFound();
            }

            _context.Deportes.Remove(deporte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeporteExists(int id)
        {
            return _context.Deportes.Any(e => e.Id == id);
        }
    }
}
