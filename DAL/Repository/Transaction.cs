using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public class Transaction
    {
         private HDATAContext context;

        private DbContextTransaction transaction;

        public Transaction()
        {
            context = new HDATAContext();
            transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public T Create<T>(T entity) where T : class
        {
            T t = context.Set<T>().Add(entity);
            context.SaveChanges();
            return t;
        }

        public void Update<T>(T entity) where T : class
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }
    }
}
