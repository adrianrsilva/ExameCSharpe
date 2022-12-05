using Dados;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Repositorio
{
    public abstract class BaseRepositorio<T> where T : class
    {

        protected Context _contexto;

        public BaseRepositorio(Context contexto)
        {

            this._contexto = contexto;

        }

        public List<T> listarTodos()
        {

            return this._contexto.Set<T>().ToList();

        }

        public List<T> listar(Expression<Func<T, bool>> expression)
        {

            return this._contexto.Set<T>().Where(expression).ToList();

        }

        public T recuperar(Expression<Func<T, bool>> expression)
        {

            return this._contexto.Set<T>().Where(expression).SingleOrDefault();

        }

        public void adicionar(T obj)
        {

            this._contexto.Set<T>().Add(obj);

        }

        public void deletar(T obj)
        {

            this._contexto.Entry(obj).State = EntityState.Deleted;

        }

        public void alterar(T obj)
        {

            this._contexto.Entry(obj).State = EntityState.Modified;

        }

        public void ativar(T obj)
        {

            this._contexto.Entry(obj).State = EntityState.Modified;

        }

        public void inativar(T obj)
        {

            this._contexto.Entry(obj).State = EntityState.Modified;

        }

        public void encerrarConta(T obj)
        {

            this._contexto.Entry(obj).State = EntityState.Deleted;

        }

    }
}
