using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GE.Dominio.Entity.Entidades;
using GE.Infraestructura.Context;

namespace GE.Presentacion.GymEvolution.Controllers.APIs.NewApis
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjerciciosController : ControllerBase
    {
        private readonly Context _context;

        public EjerciciosController(Context context)
        {
            _context = context;
        }

        // GET: api/Ejercicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ejercicio>>> GetEjercicio()
        {
            return await _context.Ejercicio.ToListAsync();
        }

        // GET: api/Ejercicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ejercicio>> GetEjercicio(long id)
        {
            var ejercicio = await _context.Ejercicio.FindAsync(id);

            if (ejercicio == null)
            {
                return NotFound();
            }

            return ejercicio;
        }

        // PUT: api/Ejercicios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEjercicio(long id, Ejercicio ejercicio)
        {
            if (id != ejercicio.Id)
            {
                return BadRequest();
            }

            _context.Entry(ejercicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EjercicioExists(id))
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

        // POST: api/Ejercicios
        [HttpPost]
        public async Task<ActionResult<Ejercicio>> PostEjercicio(Ejercicio ejercicio)
        {
            _context.Ejercicio.Add(ejercicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEjercicio", new { id = ejercicio.Id }, ejercicio);
        }

        // DELETE: api/Ejercicios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ejercicio>> DeleteEjercicio(long id)
        {
            var ejercicio = await _context.Ejercicio.FindAsync(id);
            if (ejercicio == null)
            {
                return NotFound();
            }

            _context.Ejercicio.Remove(ejercicio);
            await _context.SaveChangesAsync();

            return ejercicio;
        }

        private bool EjercicioExists(long id)
        {
            return _context.Ejercicio.Any(e => e.Id == id);
        }
    }
}
