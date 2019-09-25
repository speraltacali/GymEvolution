using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Base;

namespace GE.Repositorio.Base
{
    public interface IRepositorioPersistencia<T> where T : EntityBase
    {
        void Agregar(T entity);

        void Modificar(T entity);

        void Eliminar(long id);

        void Guardar();

    }
}
