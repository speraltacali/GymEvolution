using System;
using System.Collections.Generic;
using System.Linq;
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

        public ClaseDto Agregar(ClaseDto clase)
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
            return _claseRepositorio.ObtenerTodo()
                .Select(x => new ClaseDto()
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Descripcion = x.Descripcion,
                    FotoLink = x.Foto
                }).ToList();
        }

        public IEnumerable<ClaseDto> ObtenerPorFiltro(string cadena)
        {
            return _claseRepositorio.ObtenerPorFiltro(x => x.Nombre.Contains(cadena)
                                                           || x.Descripcion.Contains(cadena)).Select(x => new ClaseDto()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                FotoLink = x.Foto
            }).ToList();
        }

        public ClaseDto ObtenerPorId(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
