using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GE.Dominio.Entity.Entidades;
using GE.Infraestructura.Context;
using GE.Dominio.Repositorio.Clase;
using GE.Infraestructura.Repositorio.Clase;

namespace GE.Presentacion.GymEvolution.Controllers.APIs.NewApis
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasesController : ControllerBase
    {
        private readonly Context _context;
        private readonly IClaseRepositorio claseRepositorio = new ClaseRepositorio();

        public ClasesController(Context context)
        {
            _context = context;
        }

        // GET: api/Clases
        [HttpGet]
        public IEnumerable<Clase> GetClase()
        {
            return claseRepositorio.ObtenerTodo();
        }

        // GET: api/Clases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clase>> GetClase(long id)
        {
            var clase = await _context.Clase.FindAsync(id);

            if (clase == null)
            {
                return NotFound();
            }

            return clase;
        }

        // PUT: api/Clases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClase(long id, Clase clase)
        {
            if (id != clase.Id)
            {
                return BadRequest();
            }

            _context.Entry(clase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaseExists(id))
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

        // POST: api/Clases
        [HttpPost]
        public async Task<ActionResult<Clase>> PostClase(Clase clase)
        {
            _context.Clase.Add(clase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClase", new { id = clase.Id }, clase);
        }

        // DELETE: api/Clases/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clase>> DeleteClase(long id)
        {
            var clase = await _context.Clase.FindAsync(id);
            if (clase == null)
            {
                return NotFound();
            }

            _context.Clase.Remove(clase);
            await _context.SaveChangesAsync();

            return clase;
        }

        private bool ClaseExists(long id)
        {
            return _context.Clase.Any(e => e.Id == id);
        }
    }
}
