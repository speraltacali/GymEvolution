using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GE.Dominio.Entity;
using GE.Repositorio;
using GE.Repositorio.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesApiController : ControllerBase
    {
        private readonly IRepositorio<Cliente> _clienteRepositorio;

        public ClientesApiController(Repositorio<Cliente> clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpGet]
        public IEnumerable<Cliente> ObtenerCliente()
        {
            return _clienteRepositorio.ObtenerTodo();
        }
    }
}