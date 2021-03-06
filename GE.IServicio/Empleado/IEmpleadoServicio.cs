﻿using System;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Empleado.DTO;
using static System.Net.Mime.MediaTypeNames;

namespace GE.IServicio.Empleado
{
    public interface IEmpleadoServicio
    {

        EmpleadoDto Agregar(EmpleadoDto empleadoDto);

        EmpleadoDto Modificar(EmpleadoDto empleadoDto);

        void Eliminar(long id);

        IEnumerable<EmpleadoDto> ObtenerTodo();

        IEnumerable<EmpleadoDto> ObtenerPorFiltro(string cadena);

        EmpleadoDto ObtenerPorId(long id);

    }
}
