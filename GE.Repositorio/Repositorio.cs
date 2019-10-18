using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GE.Dominio.Base;
using GE.Infraestructura.Context;
using GE.Repositorio.Base;
using Microsoft.EntityFrameworkCore;

namespace GE.Repositorio
{
    public class Repositorio<T> : IRepositorio<T>  where T : EntityBase
    {
        protected Context Context;

        public Repositorio()
            : this(new Context())
        {
        }

        public Repositorio(Context context)
        {
            Context = context;
        }

        public void Agregar(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Eliminar(long id)
        {
            var entity = ObtenerPorId(id);
            Context.Set<T>().Remove(entity);
        }

        //=====================================================================================================================================//
        public IEnumerable<T> ObtenerTodo()
        {
            return Context.Set<T>().AsNoTracking().ToList();
        }

        public IEnumerable<T> ObtenerTodo(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        public IEnumerable<T> ObtenerTodo(string includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            query = includeProperties.Split('.').Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        //=====================================================================================================================================//
        public IEnumerable<T> ObtenerPorFiltro(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<T> ObtenerPorFiltro(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        public IEnumerable<T> ObtenerPorFiltro(Expression<Func<T, bool>> predicate, string includeProperties)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            query = includeProperties.Split('.').Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        //=====================================================================================================================================//
        public T ObtenerPorId(long entidadId)
        {
            return Context.Set<T>().Find(entidadId);
        }

        public T ObtenerPorId(long id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.FirstOrDefault(x => x.Id == id);
        }

        public T ObtenerPorId(long id, string includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();

            query = includeProperties.Split('.').Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.FirstOrDefault(x => x.Id == id);
        }

        //====================================================================================================================================//
        public void Guardar()
        {
            Context.SaveChanges();
        }

        public void Modificar(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
