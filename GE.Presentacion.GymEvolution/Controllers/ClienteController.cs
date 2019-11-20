using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GE.Dominio.Entity;
using GE.IServicio.Caja;
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

        private ClienteDto models;

        private IClienteServicio _clienteRepositorio = new ClienteServicio();

        private ICajaServicio _cajaServicio = new CajaServicio();

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

        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                //return View();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }
        }


        [HttpPost]
        public ActionResult Create(ClienteDto cliente)
        {

            if (ModelState.IsValid)
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

                var Cliente = _clienteRepositorio.Agregar(cliente);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

            

        }

        public ActionResult Perfil(long id)
        {
            if (HttpContext.Session.GetString("Session") != null)
            {
                ViewBag.Session = HttpContext.Session.GetString("Session");
                TempData["Session"] = HttpContext.Session.GetString("Session");
                var cliente = _clienteRepositorio.ObtenerPorId(id);

                if (_cajaServicio.VerSiCajaEstaAbierta())
                {
                    ViewBag.sms = "error";
                }

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