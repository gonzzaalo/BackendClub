using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClubBackend.DataContext;

namespace CLubBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SociosController : ControllerBase
    {
        private readonly ClubContext _context;

        public SociosController(ClubContext context)
        {
            _context = context;
        }

        // GET: api/Socios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Socio>>> GetSocios()
        {
            var socios = await _context.Socios
                .Include(s => s.Cuota)  // Incluir la relación Cuota
                .ToListAsync();

            return socios;
        }

        // GET: api/Socios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Socio>> GetSocio(int id)
        {
            var socio = await _context.Socios
                .Include(s => s.Cuota)  // Incluir la relación Cuota
                .FirstOrDefaultAsync(s => s.Id == id);

            if (socio == null)
            {
                return NotFound();
            }

            return socio;
        }

        // Otros métodos (PUT, POST, DELETE) se mantienen igual...
    }
}
