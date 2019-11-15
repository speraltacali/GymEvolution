using System;
using System.Collections.Generic;
using System.Linq;
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

        public ClaseDetalleDto Agregar(ClaseDetalleDto dto)
        {
            var claseDetalle = new ClaseDetalle
            {
                HoraInicio = dto.HoraInicio,
                HoraFin = dto.HoraFin,
                Dia = dto.Dia,
                ClaseId = dto.ClaseId
            };

            _detalleRepositorio.Agregar(claseDetalle);
            _detalleRepositorio.Guardar();

            dto.Id = claseDetalle.Id;
            return dto;
        }

        public ClaseDetalleDto Modificar(ClaseDetalleDto dto)
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

        public void Eliminar(long Id)
        {
            var detalle = _detalleRepositorio.ObtenerPorId(Id);

            if (detalle != null)
            {
                _detalleRepositorio.Eliminar(Id);
                _detalleRepositorio.Guardar();
            }
        }

        public IEnumerable<ClaseDetalleDto> ObtenerSegunClase(long ClaseId)
        {
            return _detalleRepositorio.ObtenerPorFiltro(x => ClaseId == ClaseId)
                .Select(x => new ClaseDetalleDto()
                {
                    HoraInicio = x.HoraInicio,
                    HoraFin = x.HoraFin,
                    Dia = x.Dia,
                    ClaseId = x.ClaseId
                }).ToList();
        }
    }
}
