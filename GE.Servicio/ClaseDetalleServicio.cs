using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Repositorio.Clase;
using GE.Dominio.Repositorio.ClaseDetalle;
using GE.Infraestructura.Repositorio.Clase;
using GE.Infraestructura.Repositorio.ClaseDetalle;
using GE.IServicio.Clase.DTOs;

namespace GE.Servicio
{
    public class ClaseDetalleServicio : IClaseDetalleServicio
    {
        private readonly IClaseDetalleRepositorio _detalleRepositorio = new ClaseDetalleRepositorio();

        public ClaseDetalleDto Guardar(ClaseDetalleDto dto)
        {
            try
            {
                var claseDetalle = new ClaseDetalle
                {
                    HoraInicio   = dto.HoraInicio,
                    HoraFin = dto.HoraFin,
                    Dia = dto.Dia,
                    ClaseId = dto.ClaseId
                };

                _detalleRepositorio.Agregar(claseDetalle);
                _detalleRepositorio.Guardar();

                dto.Id = claseDetalle.Id;
                return dto;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en la Operacion");
                throw;
            }
        }

        public ClaseDetalleDto Modificar(ClaseDetalleDto dto)
        {
            try
            {
                var detalle = _detalleRepositorio.ObtenerPorId(dto.Id);

                detalle.HoraInicio = dto.HoraInicio;
                detalle.HoraFin = dto.HoraFin;
                detalle.Dia = dto.Dia;
                detalle.ClaseId = dto.ClaseId;

                _detalleRepositorio.Modificar(detalle);
                _detalleRepositorio.Guardar();

                return dto;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en la Operacion");
                throw;
            }
        }

        public void Eliminar(long Id)
        {
            try
            {
                var detalle = _detalleRepositorio.ObtenerPorId(Id);

                if (detalle != null)
                {
                    _detalleRepositorio.Eliminar(Id);
                    _detalleRepositorio.Guardar();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en la Operacion");
                throw;
            }
        }
    }
}
