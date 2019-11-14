using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Repositorio.Ejercicio;
using GE.Repositorio;

namespace GE.Infraestructura.Repositorio.Ejercicio
{
    public class EjercicioRepositorio : Repositorio<Dominio.Entity.Entidades.Ejercicio> , IEjercicioRepositorio 
    {
    }
}
