using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAPI.Models;
using SistemaAPI.Models.DTOs;

namespace SistemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadDiariumsController : ControllerBase
    {
        private readonly SistemaDBContext _context;

        public ActividadDiariumsController(SistemaDBContext context)
        {
            _context = context;
        }

        // GET: api/ActividadDiariums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActividadDiarium>>> GetActividadDiaria()
        {
            return await _context.ActividadDiaria.ToListAsync();
        }

        // GET: api/ActividadDiariums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActividadDiarium>> GetActividadDiarium(int id)
        {
            var actividadDiarium = await _context.ActividadDiaria.FindAsync(id);

            if (actividadDiarium == null)
            {
                return NotFound();
            }

            return actividadDiarium;
        }

        // PUT: api/ActividadDiariums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividadDiarium(int id, ActividadDiarium actividadDiarium)
        {
            if (id != actividadDiarium.Idactividad)
            {
                return BadRequest();
            }

            _context.Entry(actividadDiarium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadDiariumExists(id))
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

        // POST: api/ActividadDiariums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActividadDTO>> Ad(ActividadDTO actividadDiarium)
        {
            ActividadDiarium nuevaActividad = new()
            {
                Fecha = DateTime.Now.Date,
                HoraEntrada = actividadDiarium.HoraEntrada,
                HoraSalida = actividadDiarium.HoraSalida,
                Lugar = actividadDiarium.Lugar,
                Descripcion = actividadDiarium.Descripcion,
                TipoActividadIdtipo = actividadDiarium.TipoActividadIdtipo,
                GastoDiarioIdgasto = actividadDiarium.GastoDiarioIdgasto,
                VehiculoIdvehiculo = actividadDiarium.VehiculoIdvehiculo,
                GastoDiarioIdgastoNavigation = null,
                TipoActividadIdtipoNavigation = null,
                VehiculoIdvehiculoNavigation = null
            };
            _context.ActividadDiaria.Add(nuevaActividad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActividadDiarium", new { id = nuevaActividad.Idactividad }, actividadDiarium);
        }

        // DELETE: api/ActividadDiariums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActividadDiarium(int id)
        {
            var actividadDiarium = await _context.ActividadDiaria.FindAsync(id);
            if (actividadDiarium == null)
            {
                return NotFound();
            }

            _context.ActividadDiaria.Remove(actividadDiarium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActividadDiariumExists(int id)
        {
            return _context.ActividadDiaria.Any(e => e.Idactividad == id);
        }
    }
}
