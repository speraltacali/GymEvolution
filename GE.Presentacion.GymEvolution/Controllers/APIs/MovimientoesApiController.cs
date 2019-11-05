using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GE.Dominio.Entity.Entidades;
using GE.Infraestructura.Context;
using GE.IServicio.Movimiento;
using GE.IServicio.Movimiento.DTO;
using GE.Servicio;

namespace GE.Presentacion.GymEvolution.Controllers.APIs
{
    [Route("api/[controller]")]
    //[ApiController]
    public class MovimientoesApiController : Controller
    {
        private readonly Context _context;

        private IMovimientoServicio _movimientoServicio = new MovimientoServicio();

        public MovimientoesApiController(Context context)
        {
            _context = context;
        }

        // GET: api/MovimientoesApi
        [HttpGet]
        public IEnumerable<MovimientoDto> GetMovimiento()
        {
            return _movimientoServicio.ListaTodosLosMovimientos();
        }

        // GET: api/MovimientoesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movimiento>> GetMovimiento(long id)
        {
            var movimiento = await _context.Movimiento.FindAsync(id);

            if (movimiento == null)
            {
                return NotFound();
            }

            return movimiento;
        }

        // PUT: api/MovimientoesApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimiento(long id, Movimiento movimiento)
        {
            if (id != movimiento.Id)
            {
                return BadRequest();
            }

            _context.Entry(movimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientoExists(id))
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

        // POST: api/MovimientoesApi
        [HttpPost]
        public async Task<ActionResult<Movimiento>> PostMovimiento(Movimiento movimiento)
        {
            _context.Movimiento.Add(movimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovimiento", new { id = movimiento.Id }, movimiento);
        }

        // DELETE: api/MovimientoesApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movimiento>> DeleteMovimiento(long id)
        {
            var movimiento = await _context.Movimiento.FindAsync(id);
            if (movimiento == null)
            {
                return NotFound();
            }

            _context.Movimiento.Remove(movimiento);
            await _context.SaveChangesAsync();

            return movimiento;
        }

        private bool MovimientoExists(long id)
        {
            return _context.Movimiento.Any(e => e.Id == id);
        }
    }
}
