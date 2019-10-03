using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Cliente;
using GE.IServicio.Cliente.DTO;
using GE.Servicio;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class ClienteController : Controller
    {

        private IClienteServicio _clienteRepositorio = new ClienteServicio();

        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = _clienteRepositorio.ObtenerTodo();
            return View(cliente);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(ClienteDto cliente)
        {
            if (cliente.Foto != null)
            {
                //guarda la imagen en la carpeta wwwroot/imgsistema
                var path = $"wwwroot\\imgsistema\\{cliente.Foto.FileName}";

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    cliente.Foto.CopyTo(stream);
                }

                //guarda en la base de datos
                cliente.FotoLink = $"/imgsistema/{cliente.Foto.FileName}";
            }
            ///---///

            var Cliente = _clienteRepositorio.Agregar(cliente);

            return RedirectToAction("Index");
        }

        public ActionResult Update(long id)
        {
            ///---

            var cliente = _clienteRepositorio.ObtenerPorId(id);

            return View(cliente);
        }


        [HttpPost]
        public ActionResult Update(ClienteDto clienteDto)
        {
            if(clienteDto.Foto != null)
            { 
            //guarda la imagen en la carpeta wwwroot/imgsistema
            var path = $"wwwroot\\imgsistema\\{clienteDto.Foto.FileName}";

            using (var stream = new FileStream(path, FileMode.Create))
            {
                clienteDto.Foto.CopyTo(stream);
            }

            //guarda en la base de datos
            clienteDto.FotoLink = $"/imgsistema/{clienteDto.Foto.FileName}";
            }
            ///---///

            _clienteRepositorio.Modificar(clienteDto);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            var cliente = _clienteRepositorio.ObtenerPorId(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Delete(ClienteDto clienteDto)
        {
            _clienteRepositorio.Eliminar(clienteDto.Id);

            return RedirectToAction("Index");
        }
    }
}