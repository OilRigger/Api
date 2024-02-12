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
    public class DetallesPedidosController : ControllerBase
    {
        private readonly TiendaContext _context;

        public DetallesPedidosController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/DetallesPedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallesPedidos>>> GetDetallePedidos()
        {
            return await _context.DetallePedidos.ToListAsync();
        }

        // GET: api/DetallesPedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallesPedidos>> GetDetallesPedidos(int id)
        {
            var detallesPedidos = await _context.DetallePedidos.FindAsync(id);

            if (detallesPedidos == null)
            {
                return NotFound();
            }

            return detallesPedidos;
        }

        // PUT: api/DetallesPedidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallesPedidos(int id, DetallesPedidos detallesPedidos)
        {
            if (id != detallesPedidos.PedidoId)
            {
                return BadRequest();
            }

            _context.Entry(detallesPedidos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallesPedidosExists(id))
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

        // POST: api/DetallesPedidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<DetallesPedidos>> PostDetallesPedidos(DetallesPedidos detallesPedidos)
        {
            _context.DetallePedidos.Add(detallesPedidos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DetallesPedidosExists(detallesPedidos.PedidoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDetallesPedidos", new { id = detallesPedidos.PedidoId }, detallesPedidos);
        }

        // DELETE: api/DetallesPedidos/5
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallesPedidos(int id)
        {
            var detallesPedidos = await _context.DetallePedidos.FindAsync(id);
            if (detallesPedidos == null)
            {
                return NotFound();
            }

            _context.DetallePedidos.Remove(detallesPedidos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallesPedidosExists(int id)
        {
            return _context.DetallePedidos.Any(e => e.PedidoId == id);
        }
    }
}
