using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Movimiento;
using GE.IServicio.Movimiento.DTO;
using GE.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteApiController : ControllerBase
    {
        private IMovimientoServicio _movimientoServicio = new MovimientoServicio();

        // GET: api/ClienteApi
        [HttpGet]
        public IEnumerable<MovimientoDto> Get()
        {
            return _movimientoServicio.ListaTodosLosMovimientos();
        }

        // GET: api/ClienteApi/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ClienteApi
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ClienteApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
