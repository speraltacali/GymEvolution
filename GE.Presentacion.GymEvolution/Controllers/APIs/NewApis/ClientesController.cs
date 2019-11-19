using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GE.Dominio.Entity;
using GE.Infraestructura.Context;
using GE.Infraestructura.Repositorio.Cliente;
using GE.Dominio.Repositorio.Cliente;

namespace GE.Presentacion.GymEvolution.Controllers.APIs.NewApis
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepositorio _repositorio = new ClienteRepositorio();

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Cliente> GetCliente()
        {
            return _repositorio.ObtenerTodo();
        }

    }
}
