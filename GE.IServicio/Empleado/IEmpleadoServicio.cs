using System;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Empleado.DTO;

namespace GE.IServicio.Empleado
{
    public interface IEmpleadoServicio
    {
        EmpleadoDto Agregar(EmpleadoDto empleadoDto);

        EmpleadoDto Modificar(EmpleadoDto empleadoDto);

        void Eliminar(long id);

        IEnumerable<EmpleadoDto> ObtenerTodo();

        EmpleadoDto ObtenerPorId(long id);

    }
}
