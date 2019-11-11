using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Repositorio.Clase;
using GE.Infraestructura.Repositorio.Clase;
using GE.IServicio.Clase;
using GE.IServicio.Clase.DTOs;

namespace GE.Servicio
{
    public class ClaseServicio : IClaseServicio
    {
        private IClaseRepositorio _claseRepositorio = new ClaseRepositorio();

        public ClaseDto Guardar(ClaseDto clase)
        {
            var Clase = new Clase()
            {
                Nombre = clase.Nombre,
                Descripcion = clase.Descripcion,
                Foto = clase.FotoLink
            };

            _claseRepositorio.Agregar(Clase);
            _claseRepositorio.Guardar();

            clase.Id = Clase.Id;
            return clase;
        }

        public ClaseDto Modificar(ClaseDto clase)
        {
            var Clase = _claseRepositorio.ObtenerPorId(clase.Id);

            Clase.Descripcion = clase.Descripcion;
            Clase.Nombre = clase.Nombre;
            Clase.Foto = clase.FotoLink;

            _claseRepositorio.Modificar(Clase);
            _claseRepositorio.Guardar();

            return clase;
        }

        public void Eliminar(long Id)
        {
            var Clase = _claseRepositorio.ObtenerPorId(Id);
            if (Clase != null) { 

                _claseRepositorio.Eliminar(Id);
            _claseRepositorio.Guardar();
            }
        }

        public IEnumerable<ClaseDto> ObtenerTodo()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClaseDto> ObtenerPorTodo(string cadena)
        {
            throw new NotImplementedException();
        }

        public ClaseDto ObtenerPorId(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
