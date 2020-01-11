
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public abstract class Repository<T> : IRepositor<T>,IDisposable where T : class
    {
        private HDATAContext Context;

        protected Repository()
        {
            Context = HDATAContextSingleton.Instance;
            
        }

        public void Actualizar(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            this.Commit();
            //RefreshEntity(entity);
        }

        public void ActualizarCampo(T entity, string field)
        {
            Context.Entry(entity).Property(field).IsModified = true;
            this.Commit();
         //   RefreshEntity(entity);
        }

        public void Cadastrar(T entity)
        {
            
            Context.Set<T>().Add(entity);
            this.Commit();
         //   RefreshEntity(entity);
        }

        public T CadastrarT(T entity)
        {
            T t = Context.Set<T>().Add(entity);
            this.Commit();
          //  RefreshEntity(entity);


            return t;
        }

        public void Commit()
        {
            Context.SaveChanges();

        }

        public void CommitAsync()
        {
            Context.SaveChangesAsync();
        }

        public List<T> Consultar(Expression<Func<T, bool>> predicate)
        {
            
            var Result = Context.Set<T>().Where(predicate).ToList();
          //  Dispose();
           // Context = BibliogestDataContextSingleton.Instance;
            return Result;
        }

        public Task<List<T>> ConsultarAsync(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<T> ConsultarAsync(params object[] key)
        {
            return Context.Set<T>().FindAsync(key);
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public void Eliminar(Func<T, bool> predicate)
        {
            Context.Set<T>()
           .Where(predicate).ToList()
           .ForEach(del => Context.Set<T>().Remove(del));
            Commit();
        }

        public List<T> ObterTodos()
        {
            return Context.Set<T>().ToList();
        }

        public T Procurar(params object[] key)
        {
            //RefreshAll();
            var result = Context.Set<T>().Find(key);
           // Dispose();
            // Context = BibliogestDataContextSingleton.Instance;
            return result;
        }


        public Task<T> ProcurarAsync(Expression<Func<T, bool>> predicate)
        {
            
            return Context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public T ProcurarPor(Expression<Func<T, bool>> predicate)
        {
           // RefreshAll();
            return Context.Set<T>().Where(predicate).FirstOrDefault();
        }

         public void RefreshAll()
        {
                foreach (var entity in Context.ChangeTracker.Entries())
                {
                    entity.Reload();
                }
        }

       
        public void RefreshEntity(T entity)
        {
            Context.Entry<T>(entity).Reload();
        }

        public void RefreshEntity()
        {
            ((IObjectContextAdapter)this.Context)
                 .ObjectContext
                 .Refresh(RefreshMode.StoreWins, ObterTodos());
        }

        public long Count()
        {
           return Context.Set<T>().LongCount();
        }

        public long Count(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate).Count();
        }
    }
}
