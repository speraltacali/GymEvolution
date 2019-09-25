using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using GE.Dominio.Base;

namespace GE.Repositorio.Base
{
    public interface IRepositorioConsulta<T> where T : EntityBase
    {
        T ObtenerPorId(long entidadId);

        T ObternerPorId(long id, params Expression<Func<T, object>>[] incluirPropiedades);

        T ObtenerPorId(long id, string incluirPropiedades);

        //**************************************************************************************//

        IEnumerable<T> ObtenerTodo();

        IEnumerable<T> ObtenerTodo(params Expression<Func<T, object>>[] Propiedades);

        IEnumerable<T> ObtenerTodo(string incluirPropiedades);

        //**************************************************************************************//

        IEnumerable<T> ObtenerPorFiltro(Expression<Func<T, bool>> predicado);

        IEnumerable<T> ObtenerPorFiltro(Expression<Func<T, bool>> predicado,
            params Expression<Func<T, object>>[] incluirPropiedades);

        IEnumerable<T> ObtenerPorFiltro(Expression<Func<T, bool>> predicado, string incluirPropiedades);
    }
}
