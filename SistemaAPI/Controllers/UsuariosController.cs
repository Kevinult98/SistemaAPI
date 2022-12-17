using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaAPI.Models;
using SistemaAPI.Attributes;
using SistemaAPI.Tools;

namespace SistemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class UsuariosController : ControllerBase
    {
        private readonly SistemaDBContext _context;

        private Crypto MyCrypto { get; set; }

        public UsuariosController(SistemaDBContext context)
        {
            _context = context;

            MyCrypto = new Crypto();
        }


        // GET: api/Usuarios
        [HttpGet("GetUsersByID")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsersByID(int pUserID)
        {
            var NList = await _context.Usuarios.Where(e => e.Idusuario == pUserID).ToListAsync();

            if (NList == null)
            {
                return NotFound();
            }

            return NList;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpGet("ValidateUserLogin")]
        public async Task<ActionResult<Usuario>> ValidateUserLogin(string pEmail, string pPassword)
        {
            string ApiLevelEncriptedPassword = MyCrypto.EncriptarEnUnSentido(pPassword);
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(e => e.Email == 
                                                            pEmail && e.Clave == ApiLevelEncriptedPassword);
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Idusuario)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {

            string ApiLevelEncriptedPassword = MyCrypto.EncriptarEnUnSentido(usuario.Clave);

            usuario.Clave = ApiLevelEncriptedPassword;
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Idusuario }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Idusuario == id);
        }
    }
}
