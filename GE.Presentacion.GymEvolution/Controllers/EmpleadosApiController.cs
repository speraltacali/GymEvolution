using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GE.Dominio.Entity.Entidades;
using GE.Infraestructura.Context;

namespace GE.Presentacion.GymEvolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosApiController : ControllerBase
    {
        private readonly Context _context;

        public EmpleadosApiController(Context context)
        {
            _context = context;
        }

        // GET: api/EmpleadosApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleado()
        {
            return await _context.Empleado.ToListAsync();
        }

        // GET: api/EmpleadosApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(long id)
        {
            var empleado = await _context.Empleado.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        // PUT: api/EmpleadosApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(long id, Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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

        // POST: api/EmpleadosApi
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            _context.Empleado.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleado", new { id = empleado.Id }, empleado);
        }

        // DELETE: api/EmpleadosApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empleado>> DeleteEmpleado(long id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();

            return empleado;
        }

        private bool EmpleadoExists(long id)
        {
            return _context.Empleado.Any(e => e.Id == id);
        }
    }
}
