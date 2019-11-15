
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Repositorio.Ejercicio;
using GE.Infraestructura.Repositorio.Ejercicio;
using GE.IServicio.Ejercicio;
using GE.IServicio.Ejercicio.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GE.Servicio
{
    public class EjercicioServicio : IEjercicioServicio
    {
        private readonly IEjercicioRepositorio _ejercicioServicio = new EjercicioRepositorio();

        //trasforma file a byte
        private byte[] GetByteArrayFromImage(IFormFile file)
        {
            using (var target = new MemoryStream())
            {

                file.CopyTo(target);
                return target.ToArray();
            }

                Nombre = dto.Nombre,
                Repeticiones = dto.Repeticiones,
                Series = dto.Series,
                Musculo = dto.Musculo,
                Foto = dto.FotoLink,
                RutinaId = dto.RutinaId
            };

        public EjercicioDto Agregar(EjercicioDto ejercicioDto)
        {
            throw new NotImplementedException();
        }

        public EjercicioDto Modificar(EjercicioDto ejercicioDto)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EjercicioDto> ObtenerTodo()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EjercicioDto> ObtenerPorFiltro(string cadena)
        {
            throw new NotImplementedException();
        }

        public EjercicioDto ObtenerPorId(long id)
        {
            throw new NotImplementedException();
        }

        _ejercicioRepositorio.Agregar(Ejercicio);
            _ejercicioRepositorio.Guardar();

            dto.Id = Ejercicio.Id;
            return dto;

        }
        public EjercicioDto Agregar(EjercicioDto dto)
        {
            var ejercicio = new Ejercicios()
            {
                Descripcion = dto.Descripcion,
                Serie = dto.Serie,
                Repeticiones = dto.Serie,
                FotoLink = dto.FotoLink
            };


            _ejercicioServicio.Agregar(ejercicio);
            _ejercicioServicio.Guardar();

            Ejercicio.Nombre = dto.Nombre;
            Ejercicio.Repeticiones = dto.Repeticiones;
            Ejercicio.Series = dto.Series;
            Ejercicio.Musculo = dto.Musculo;
            Ejercicio.Foto = dto.FotoLink;
            Ejercicio.RutinaId = dto.RutinaId;
            dto.Id = ejercicio.Id;

            return dto;
        }

        public void Eliminar(long id)
        {
            var ejercicio = _ejercicioServicio.ObtenerPorId(id);

            if (ejercicio != null)
            {
                _ejercicioServicio.Eliminar(id);
                _ejercicioServicio.Guardar();
            }
        }

        public EjercicioDto Modificar(EjercicioDto dto)
        {

            var ejercicio = _ejercicioServicio.ObtenerPorId(dto.Id);

            ejercicio.Descripcion = dto.Descripcion;
            ejercicio.Serie = dto.Serie;
            ejercicio.Repeticiones = dto.Repeticiones;
            ejercicio.FotoLink = dto.FotoLink;

            _ejercicioServicio.Modificar(ejercicio);
            _ejercicioServicio.Guardar();

            return dto;
        }

        public IEnumerable<EjercicioDto> ObtenerPorFiltro(string cadena)
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
            var ejercicio = _ejercicioServicio.ObtenerPorId(id);

            return new EjercicioDto()
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

        public IEnumerable<EjercicioDto> ObtenerTodo()
        {

            var ejercicio = _ejercicioServicio.ObtenerTodo().Select(x => new EjercicioDto()
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                Serie = x.Serie,
                Repeticiones = x.Repeticiones,
                FotoLink = x.FotoLink
            });

            return ejercicio.ToList();

        }
    }
}
