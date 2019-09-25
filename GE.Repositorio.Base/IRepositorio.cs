using System;
using GE.Dominio.Base;

namespace GE.Repositorio.Base
{
    public interface IRepositorio<T> : IRepositorioConsulta<T>,IRepositorioPersistencia<T> where T : EntityBase
    {
    }
}
