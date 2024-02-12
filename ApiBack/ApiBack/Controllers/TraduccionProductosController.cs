using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiBack.Data;
using ApiBack.Models;

namespace ApiBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraduccionProductosController : ControllerBase
    {
        private readonly TiendaContext _context;

        public TraduccionProductosController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/TraduccionProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraduccionProductos>>> GetTraduccionProductos()
        {
            return await _context.TraduccionProductos.ToListAsync();
        }

        // GET: api/TraduccionProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TraduccionProductos>> GetTraduccionProductos(int id)
        {
            var traduccionProductos = await _context.TraduccionProductos.FindAsync(id);

            if (traduccionProductos == null)
            {
                return NotFound();
            }

            return traduccionProductos;
        }

        // PUT: api/TraduccionProductos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraduccionProductos(int id, TraduccionProductos traduccionProductos)
        {
            if (id != traduccionProductos.IdTraduccionProduct)
            {
                return BadRequest();
            }

            _context.Entry(traduccionProductos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraduccionProductosExists(id))
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

        // POST: api/TraduccionProductos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TraduccionProductos>> PostTraduccionProductos(TraduccionProductos traduccionProductos)
        {
            _context.TraduccionProductos.Add(traduccionProductos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraduccionProductos", new { id = traduccionProductos.IdTraduccionProduct }, traduccionProductos);
        }

        // DELETE: api/TraduccionProductos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraduccionProductos(int id)
        {
            var traduccionProductos = await _context.TraduccionProductos.FindAsync(id);
            if (traduccionProductos == null)
            {
                return NotFound();
            }

            _context.TraduccionProductos.Remove(traduccionProductos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraduccionProductosExists(int id)
        {
            return _context.TraduccionProductos.Any(e => e.IdTraduccionProduct == id);
        }
    }
}
