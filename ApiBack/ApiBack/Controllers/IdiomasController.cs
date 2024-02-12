using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiBack.Data;
using ApiBack.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApiBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdiomasController : ControllerBase
    {
        private readonly TiendaContext _context;

        public IdiomasController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/Idiomas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Idioma>>> GetIdiomas()
        {
            return await _context.Idiomas.ToListAsync();
        }

        // GET: api/Idiomas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Idioma>> GetIdioma(int id)
        {
            var idioma = await _context.Idiomas.FindAsync(id);

            if (idioma == null)
            {
                return NotFound();
            }

            return idioma;
        }

        // PUT: api/Idiomas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdioma(int id, Idioma idioma)
        {
            if (id != idioma.Id)
            {
                return BadRequest();
            }

            _context.Entry(idioma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdiomaExists(id))
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

        // POST: api/Idiomas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<Idioma>> PostIdioma(Idioma idioma)
        {
            _context.Idiomas.Add(idioma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIdioma", new { id = idioma.Id }, idioma);
        }

        // DELETE: api/Idiomas/5
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdioma(int id)
        {
            var idioma = await _context.Idiomas.FindAsync(id);
            if (idioma == null)
            {
                return NotFound();
            }

            _context.Idiomas.Remove(idioma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IdiomaExists(int id)
        {
            return _context.Idiomas.Any(e => e.Id == id);
        }
    }
}
