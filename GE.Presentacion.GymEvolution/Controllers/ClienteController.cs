using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GE.IServicio.Cliente;
using GE.IServicio.Cliente.DTO;
using GE.Presentacion.GymEvolution.Models;
using GE.Servicio;
using GE.Servicio.DatosEstaticos.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GE.Presentacion.GymEvolution.Controllers
{
    public class ClienteController : Controller
    {
        private DataPaginador<ClienteDto> models;
        private IClienteServicio _clienteRepositorio = new ClienteServicio();

        // GET: Cliente

        public ActionResult Index()
        {
            return View();
        }   


        [HttpGet]
        public ActionResult Index(string cadena)
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                ViewBag.Session = HttpContext.Session.GetString("Session");
                TempData["Session"] = HttpContext.Session.GetString("Session");
                ViewData["Busqueda"] = cadena;

                if (!String.IsNullOrEmpty(cadena))
                {
                    var FiltroCliente = _clienteRepositorio.ObtenerPorFiltro(cadena);
                    return View(FiltroCliente);
                }
                else
                {
                    var TodoCliente = _clienteRepositorio.ObtenerTodo();
                    return View(TodoCliente);
                }
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        //public ActionResult Create()
        //{
        //    if (HttpContext.Session.GetString("Session") != null)
        //    {
        //        //return View();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login", "Usuario");
        //    }
        //}


        [HttpPost]
        public string Create(DataPaginador<ClienteDto> cliente)
        {

            if (ModelState.IsValid)
            {
                if (cliente.Input.Foto != null)
                {
                    //guarda la imagen en la carpeta wwwroot/imgsistema
                    var path = $"wwwroot\\imgsistema\\{cliente.Input.Foto.FileName}";

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        cliente.Input.Foto.CopyTo(stream);
                    }

                    //guarda en la base de datos
                    cliente.Input.FotoLink = $"/imgsistema/{cliente.Input.Foto.FileName}";
                }

                var Cliente = _clienteRepositorio.Agregar(cliente.Input);

                return "Operacion Existosa";
                //return View("Index");
            }
            else
            {
                return "Verifique los Campos";
                //return View();
                //return View(cliente);

            }

            

        }

        public ActionResult Perfil(long id)
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                var cliente = _clienteRepositorio.ObtenerPorId(id);

                return View(cliente);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }

        public ActionResult Update(long id)
        {

            if (HttpContext.Session.GetString("Session") != null)
            {
                var cliente2 =_clienteRepositorio.ObtenerPorId(id);

                return View(cliente2);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }

        }


        [HttpPost]
        public ActionResult Update(ClienteDto clienteDto)
        { 
            if (ModelState.IsValid)
            {
                if (clienteDto.Foto != null)
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
            else
            {
                return View();
            }

            

        }

        public ActionResult Delete(long id)
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                var cliente = _clienteRepositorio.ObtenerPorId(id);

                return View(cliente);
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }

        }

        [HttpPost]
        public ActionResult Delete(ClienteDto clienteDto)
        {
            _clienteRepositorio.Eliminar(clienteDto.Id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CuotaEstado(ClienteDto clienteDto)
        {
            return RedirectToAction("CuotaEstado");
        }


    }
}