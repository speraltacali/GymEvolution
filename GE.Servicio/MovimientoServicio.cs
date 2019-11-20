using GE.Dominio.Entity.Entidades;
using GE.Dominio.Repositorio.Movimiento;
using GE.Infraestructura.Repositorio.Movimiento;
using GE.IServicio.Movimiento;
using GE.IServicio.Movimiento.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GE.Servicio
{
    public class MovimientoServicio : IMovimientoServicio
    {
        private readonly IMovimientoRepositorio _movimientoServicio;

        public IEnumerable<MovimientoDto> ListaTodosLosMovimientos()
        {

            return _movimientoServicio.ObtenerTodo().Select(x => new MovimientoDto
            {
                Descripcion = x.Descripcion,
                FechaActualizacion = x.FechaActualizacion,
                EmpleadoId = x.EmpleadoId,
                TipoMovimiento = x.TipoMovimiento,
                Monto = x.Monto

            }).ToList();

        }

        public MovimientoServicio()
        {
            _movimientoServicio = new MovimientoRepositorio();
        }

        public void NuevoMovimiento(MovimientoDto movimientoEgreso)
        {
            var movimiento = new Movimiento
            {
                Descripcion = movimientoEgreso.Descripcion,
                EmpleadoId = movimientoEgreso.EmpleadoId,
                FechaActualizacion = movimientoEgreso.FechaActualizacion,
                TipoMovimiento = movimientoEgreso.TipoMovimiento,
                Monto = movimientoEgreso.Monto
            };

            _movimientoServicio.Agregar(movimiento);

            _movimientoServicio.Guardar();
        }

        public IEnumerable<MovimientoDto> ObtenerFechaDesdeHasta(DateTime desde, DateTime hasta)
        {
            return _movimientoServicio.ObtenerPorFiltro(x => x.FechaActualizacion.Date >= desde.Date
            && x.FechaActualizacion.Date <= hasta.Date).Select(x => new MovimientoDto
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                EmpleadoId = x.EmpleadoId,
                FechaActualizacion = x.FechaActualizacion,
                TipoMovimiento = x.TipoMovimiento,
                Monto = x.Monto

            }).ToList();
        }

        public IEnumerable<MovimientoDto> ObtenerPorDescripcion(string cadena)
        {
            return _movimientoServicio.ObtenerPorFiltro(x => x.Descripcion.Contains(cadena)).Select(x => new MovimientoDto
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                EmpleadoId = x.EmpleadoId,
                FechaActualizacion = x.FechaActualizacion,
                TipoMovimiento = x.TipoMovimiento,
                Monto = x.Monto

            }).ToList();
        }

        public IEnumerable<MovimientoDto> ObtenerPorFecha(DateTime fecha)
        {
            return _movimientoServicio.ObtenerPorFiltro(x => x.FechaActualizacion.Date == fecha.Date).Select(x => new MovimientoDto
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                EmpleadoId = x.EmpleadoId,
                FechaActualizacion = x.FechaActualizacion,
                TipoMovimiento = x.TipoMovimiento,
                Monto = x.Monto

            }).ToList();
        }


        public IEnumerable<MovimientoDto> ObtenerPorEmpleado(long id)
        {
            return _movimientoServicio.ObtenerPorFiltro(x => x.EmpleadoId == id)
                .Select(x => new MovimientoDto()
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    EmpleadoId = x.EmpleadoId,
                    FechaActualizacion = x.FechaActualizacion,
                    TipoMovimiento = x.TipoMovimiento,
                    Monto = x.Monto
                }).ToList();
        }
    }
}
