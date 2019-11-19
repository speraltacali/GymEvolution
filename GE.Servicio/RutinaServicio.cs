using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Repositorio.Rutina;
using GE.Infraestructura.Repositorio.Rutina;
using GE.IServicio.Rutina;
using GE.IServicio.Rutina.DTO;

namespace GE.Servicio
{
    public class RutinaServicio : IRutinaServicio
    {
        private readonly IRutinaRepositorio _rutinaRepositorio = new RutinaRepositorio();

        public RutinaDto Agregar(RutinaDto dto)
        {
            var Rutina = new Rutina
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion
            };

            _rutinaRepositorio.Agregar(Rutina);
            _rutinaRepositorio.Guardar();

            dto.Id = Rutina.Id;
            return dto;
        }

        public RutinaDto Modificar(RutinaDto dto)
        {
            var Rutina = _rutinaRepositorio.ObtenerPorId(dto.Id);

            Rutina.Titulo = dto.Titulo;
            Rutina.Descripcion = dto.Descripcion;

            _rutinaRepositorio.Modificar(Rutina);
            _rutinaRepositorio.Guardar();

            return dto;
        }

        public void Eliminar(long id)
        {
            var Rutina = _rutinaRepositorio.ObtenerPorId(id);

            if (Rutina != null)
            {
                _rutinaRepositorio.Eliminar(id);
                _rutinaRepositorio.Guardar();
            }
        }

        public IEnumerable<RutinaDto> ObtenerTodo()
        {
            return _rutinaRepositorio.ObtenerTodo()
                .Select(x => new RutinaDto()
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Descripcion = x.Descripcion
                }).ToList();
        }

        public RutinaDto ObtenerPorId(long id)
        {
            var Rutina = _rutinaRepositorio.ObtenerPorId(id);

            return new RutinaDto()
            {
                Id = Rutina.Id,
                Titulo = Rutina.Titulo,
                Descripcion = Rutina.Descripcion
            };
        }

        public IEnumerable<RutinaDto> ObtenerPorFiltro(string cadena)
        {
            return _rutinaRepositorio.ObtenerPorFiltro(x=>x.Titulo.Contains(cadena) || 
                                                          x.Descripcion.Contains(cadena))
                .Select(x => new RutinaDto()
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Descripcion = x.Descripcion
                }).ToList();
        }
    }
}
