using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Repositorio.Empleado;
using GE.Repositorio;

namespace GE.Infraestructura.Repositorio.Empleado
{
    public class EmpleadoRepositorio : Repositorio<Dominio.Entity.Entidades.Empleado> , IEmpleadoRepositorio
    {
    }
}
