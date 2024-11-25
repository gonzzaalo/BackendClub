using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubBackend.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CLubBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly ClubContext _context;

        public ProfesoresController(ClubContext context)
        {
            _context = context;
        }

        // GET: api/Profesores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesor>>> GetProfesores()
        {
            var profesores = await _context.Profesores
                .Include(p => p.Deportes)  // Incluir la relación Deportes
                .ToListAsync();

            return profesores;
        }

        // GET: api/Profesores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> GetProfesor(int id)
        {
            var profesor = await _context.Profesores
                .Include(p => p.Deportes)  // Incluir la relación Deportes
                .FirstOrDefaultAsync(p => p.Id == id);

            if (profesor == null)
            {
                return NotFound();
            }

            return profesor;
        }

        // Otros métodos (PUT, POST, DELETE) se mantienen igual...
    }
}
