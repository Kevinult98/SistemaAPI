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
    public class GastoDiariosController : ControllerBase
    {
        private readonly SistemaDBContext _context;

        public GastoDiariosController(SistemaDBContext context)
        {
            _context = context;
        }

        // GET: api/GastoDiarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GastoDiario>>> GetGastoDiarios()
        {
            return await _context.GastoDiarios.ToListAsync();
        }

        // GET: api/GastoDiarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GastoDiario>> GetGastoDiario(int id)
        {
            var gastoDiario = await _context.GastoDiarios.FindAsync(id);

            if (gastoDiario == null)
            {
                return NotFound();
            }

            return gastoDiario;
        }

        // PUT: api/GastoDiarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGastoDiario(int id, GastoDiario gastoDiario)
        {
            if (id != gastoDiario.Idgasto)
            {
                return BadRequest();
            }

            _context.Entry(gastoDiario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GastoDiarioExists(id))
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

        // POST: api/GastoDiarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GastoDiario>> PostGastoDiario(GastoDiario gastoDiario)
        {
            _context.GastoDiarios.Add(gastoDiario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGastoDiario", new { id = gastoDiario.Idgasto }, gastoDiario);
        }

        // DELETE: api/GastoDiarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGastoDiario(int id)
        {
            var gastoDiario = await _context.GastoDiarios.FindAsync(id);
            if (gastoDiario == null)
            {
                return NotFound();
            }

            _context.GastoDiarios.Remove(gastoDiario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GastoDiarioExists(int id)
        {
            return _context.GastoDiarios.Any(e => e.Idgasto == id);
        }
    }
}
