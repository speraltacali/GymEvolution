using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Repositorio.Ejercicio;
using GE.Infraestructura.Repositorio.Ejercicio;
using GE.IServicio.Ejercicio;
using GE.IServicio.Ejercicio.DTO;

namespace GE.Servicio
{
    public class EjercicioServicio : IEjercicioServicio
    {
        private readonly  IEjercicioRepositorio _ejercicioRepositorio = new EjercicioRepositorio();
        public EjercicioDto Agregar(EjercicioDto dto)
        {
            var Ejercicio = new Ejercicio
            {
                Nombre = dto.Nombre,
                Repeticiones = dto.Repeticiones,
                Series = dto.Series,
                Musculo = dto.Musculo,
                Foto = dto.FotoLink,
                RutinaId = dto.RutinaId
            };

            _ejercicioRepositorio.Agregar(Ejercicio);
            _ejercicioRepositorio.Guardar();

            dto.Id = Ejercicio.Id;
            return dto;
        }

        public EjercicioDto Modificar(EjercicioDto dto)
        {
            var Ejercicio = _ejercicioRepositorio.ObtenerPorId(dto.Id);

            Ejercicio.Nombre = dto.Nombre;
            Ejercicio.Repeticiones = dto.Repeticiones;
            Ejercicio.Series = dto.Series;
            Ejercicio.Musculo = dto.Musculo;
            Ejercicio.Foto = dto.FotoLink;
            Ejercicio.RutinaId = dto.RutinaId; 

            _ejercicioRepositorio.Modificar(Ejercicio);
            _ejercicioRepositorio.Guardar();

            return dto;
        }

        public void Eliminar(long id)
        {
            var Ejercicio = _ejercicioRepositorio.ObtenerPorId(id);

            if (Ejercicio != null)
            {
                _ejercicioRepositorio.Eliminar(id);
                _ejercicioRepositorio.Guardar();
            }
        }

        public IEnumerable<EjercicioDto> ObtenerTodo()
        {
            return _ejercicioRepositorio.ObtenerTodo()
                .Select(x => new EjercicioDto()
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Repeticiones = x.Repeticiones,
                    Series = x.Series,
                    Musculo = x.Musculo,
                    FotoLink = x.Foto,
                    RutinaId = x.RutinaId
                }).ToList();
        }

        public EjercicioDto ObtenerPorId(long id)
        {
            var Ejercicio = _ejercicioRepositorio.ObtenerPorId(id);

            return new EjercicioDto
            {
                Id = Ejercicio.Id,
                Nombre = Ejercicio.Nombre,
                Repeticiones = Ejercicio.Repeticiones,
                Series = Ejercicio.Series,
                Musculo = Ejercicio.Musculo,
                FotoLink = Ejercicio.Foto,
                RutinaId = Ejercicio.RutinaId
            };
        }

        public IEnumerable<EjercicioDto> ObtenerPorFiltro(string cadena)
        {
            return _ejercicioRepositorio.ObtenerPorFiltro(x=>x.Nombre.Contains(cadena))
                .Select(x => new EjercicioDto()
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Repeticiones = x.Repeticiones,
                    Series = x.Series,
                    Musculo = x.Musculo,
                    FotoLink = x.Foto,
                    RutinaId = x.RutinaId
                }).ToList();
        }
    }
}
