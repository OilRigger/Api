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
    public class ImagenProductosController : ControllerBase
    {
        private readonly TiendaContext _context;

        public ImagenProductosController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/ImagenProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImagenProductos>>> GetProductoImagenes()
        {
            return await _context.ProductoImagenes.ToListAsync();
        }

        // GET: api/ImagenProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImagenProductos>> GetImagenProductos(int id)
        {
            var imagenProductos = await _context.ProductoImagenes.FindAsync(id);

            if (imagenProductos == null)
            {
                return NotFound();
            }

            return imagenProductos;
        }

        // PUT: api/ImagenProductos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImagenProductos(int id, ImagenProductos imagenProductos)
        {
            if (id != imagenProductos.Id)
            {
                return BadRequest();
            }

            _context.Entry(imagenProductos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagenProductosExists(id))
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

        // POST: api/ImagenProductos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<ImagenProductos>> PostImagenProductos(ImagenProductos imagenProductos)
        {
            _context.ProductoImagenes.Add(imagenProductos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImagenProductos", new { id = imagenProductos.Id }, imagenProductos);
        }

        // DELETE: api/ImagenProductos/5
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagenProductos(int id)
        {
            var imagenProductos = await _context.ProductoImagenes.FindAsync(id);
            if (imagenProductos == null)
            {
                return NotFound();
            }

            _context.ProductoImagenes.Remove(imagenProductos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImagenProductosExists(int id)
        {
            return _context.ProductoImagenes.Any(e => e.Id == id);
        }
    }
}
