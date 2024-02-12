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
    public class TraduccionCategoriasController : ControllerBase
    {
        private readonly TiendaContext _context;

        public TraduccionCategoriasController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/TraduccionCategorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraduccionCategorias>>> GetTraduccionCategorias()
        {
            return await _context.TraduccionCategorias.ToListAsync();
        }

        // GET: api/TraduccionCategorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TraduccionCategorias>> GetTraduccionCategorias(int id)
        {
            var traduccionCategorias = await _context.TraduccionCategorias.FindAsync(id);

            if (traduccionCategorias == null)
            {
                return NotFound();
            }

            return traduccionCategorias;
        }

        // PUT: api/TraduccionCategorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraduccionCategorias(int id, TraduccionCategorias traduccionCategorias)
        {
            if (id != traduccionCategorias.IdTraduccionCategoria)
            {
                return BadRequest();
            }

            _context.Entry(traduccionCategorias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraduccionCategoriasExists(id))
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

        // POST: api/TraduccionCategorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TraduccionCategorias>> PostTraduccionCategorias(TraduccionCategorias traduccionCategorias)
        {
            _context.TraduccionCategorias.Add(traduccionCategorias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraduccionCategorias", new { id = traduccionCategorias.IdTraduccionCategoria }, traduccionCategorias);
        }

        // DELETE: api/TraduccionCategorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraduccionCategorias(int id)
        {
            var traduccionCategorias = await _context.TraduccionCategorias.FindAsync(id);
            if (traduccionCategorias == null)
            {
                return NotFound();
            }

            _context.TraduccionCategorias.Remove(traduccionCategorias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TraduccionCategoriasExists(int id)
        {
            return _context.TraduccionCategorias.Any(e => e.IdTraduccionCategoria == id);
        }
    }
}
