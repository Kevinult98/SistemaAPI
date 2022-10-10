using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAPI.Models;

namespace SistemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoActividadsController : ControllerBase
    {
        private readonly SistemaDBContext _context;

        public TipoActividadsController(SistemaDBContext context)
        {
            _context = context;
        }

        // GET: api/TipoActividads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoActividad>>> GetTipoActividads()
        {
            return await _context.TipoActividads.ToListAsync();
        }

        // GET: api/TipoActividads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoActividad>> GetTipoActividad(int id)
        {
            var tipoActividad = await _context.TipoActividads.FindAsync(id);

            if (tipoActividad == null)
            {
                return NotFound();
            }

            return tipoActividad;
        }

        // PUT: api/TipoActividads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoActividad(int id, TipoActividad tipoActividad)
        {
            if (id != tipoActividad.Idtipo)
            {
                return BadRequest();
            }

            _context.Entry(tipoActividad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoActividadExists(id))
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

        // POST: api/TipoActividads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoActividad>> PostTipoActividad(TipoActividad tipoActividad)
        {
            _context.TipoActividads.Add(tipoActividad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoActividad", new { id = tipoActividad.Idtipo }, tipoActividad);
        }

        // DELETE: api/TipoActividads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoActividad(int id)
        {
            var tipoActividad = await _context.TipoActividads.FindAsync(id);
            if (tipoActividad == null)
            {
                return NotFound();
            }

            _context.TipoActividads.Remove(tipoActividad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoActividadExists(int id)
        {
            return _context.TipoActividads.Any(e => e.Idtipo == id);
        }
    }
}
