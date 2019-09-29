using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Repositorio.Empleado;
using GE.Infraestructura.Repositorio.Empleado;
using GE.IServicio.Empleado;
using GE.IServicio.Empleado.DTO;

namespace GE.Servicio
{
    public class EmpleadoServicio : IEmpleadoServicio
    {
        private readonly IEmpleadoRepositorio _empleadoServicio = new EmpleadoRepositorio();
        public EmpleadoDto Agregar(EmpleadoDto dto)
        {
            var empleado = new Empleado()
            {
                Apellido = dto.Apellido,
                Nombre = dto.Nombre,
                Dni = dto.Dni,
                Domicilio = dto.Domicilio,
                Telefono = dto.Telefono,
                FechaNacimiento = dto.FechaNacimiento,
                Sexo = dto.Sexo,
                Legajo = dto.Legajo
            };

            _empleadoServicio.Agregar(empleado);
            _empleadoServicio.Guardar();

            dto.Id = empleado.Id;

            return dto;

        }

        public EmpleadoDto Modificar(EmpleadoDto dto)
        {
            var empleado = _empleadoServicio.ObtenerPorId(dto.Id);

            empleado.Apellido = dto.Apellido;
            empleado.Nombre = dto.Nombre;
            empleado.Dni = dto.Dni;
            empleado.Domicilio = dto.Domicilio;
            empleado.Telefono = dto.Telefono;
            empleado.FechaNacimiento = dto.FechaNacimiento;
            empleado.Sexo = dto.Sexo;
            empleado.Legajo = dto.Legajo;

            _empleadoServicio.Modificar(empleado);
            _empleadoServicio.Guardar();

            return dto;

        }

        public void Eliminar(long id)
        {
            var empleado = _empleadoServicio.ObtenerPorId(id);

            if (empleado != null)
            {
                _empleadoServicio.Eliminar(id);
                _empleadoServicio.Guardar();
            }
        }

        public IEnumerable<EmpleadoDto> ObtenerTodo()
        {
            return _empleadoServicio.ObtenerTodo().Select(x => new EmpleadoDto()
            {
                Id = x.Id,
                Apellido = x.Apellido,
                Nombre = x.Nombre,
                Dni = x.Dni,
                Domicilio = x.Domicilio,
                Telefono = x.Telefono,
                FechaNacimiento = x.FechaNacimiento,
                Sexo = x.Sexo,
                Legajo = x.Legajo
            }).ToList();
        }

        public EmpleadoDto ObtenerPorId(long id)
        {
            var empleado = _empleadoServicio.ObtenerPorId(id);

            return new EmpleadoDto()
            {
                Id = empleado.Id,
                Apellido = empleado.Apellido,
                Nombre = empleado.Nombre,
                Dni = empleado.Dni,
                Domicilio = empleado.Domicilio,
                Telefono = empleado.Telefono,
                FechaNacimiento = empleado.FechaNacimiento,
                Sexo = empleado.Sexo,
                Legajo = empleado.Legajo
            };
        }
    }
}
