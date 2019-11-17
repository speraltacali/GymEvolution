using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GE.Dominio.Entity.Entidades;
using GE.Infraestructura.Context;
using GE.Dominio.Repositorio.Rutina;
using GE.Infraestructura.Repositorio.Rutina;

namespace GE.Presentacion.GymEvolution.Controllers.APIs.NewApis
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutinasController : ControllerBase
    {
        private readonly Context _context;
        private readonly IRutinaRepositorio rutinaRepositorio = new RutinaRepositorio();

        public RutinasController(Context context)
        {
            _context = context;
        }

        // GET: api/Rutinas
        [HttpGet]
        public IEnumerable<Rutina> GetRutina()
        {
            return rutinaRepositorio.ObtenerTodo();
        }

        // GET: api/Rutinas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rutina>> GetRutina(long id)
        {
            var rutina = await _context.Rutina.FindAsync(id);

            if (rutina == null)
            {
                return NotFound();
            }

            return rutina;
        }

        // PUT: api/Rutinas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRutina(long id, Rutina rutina)
        {
            if (id != rutina.Id)
            {
                return BadRequest();
            }

            _context.Entry(rutina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutinaExists(id))
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

        // POST: api/Rutinas
        [HttpPost]
        public async Task<ActionResult<Rutina>> PostRutina(Rutina rutina)
        {
            _context.Rutina.Add(rutina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRutina", new { id = rutina.Id }, rutina);
        }

        // DELETE: api/Rutinas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rutina>> DeleteRutina(long id)
        {
            var rutina = await _context.Rutina.FindAsync(id);
            if (rutina == null)
            {
                return NotFound();
            }

            _context.Rutina.Remove(rutina);
            await _context.SaveChangesAsync();

            return rutina;
        }

        private bool RutinaExists(long id)
        {
            return _context.Rutina.Any(e => e.Id == id);
        }
    }
}
