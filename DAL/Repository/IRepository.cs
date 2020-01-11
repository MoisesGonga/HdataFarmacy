using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepositor<T> where T : class
    {
        List<T> ObterTodos();
        List<T> Consultar(Expression<Func<T, bool>> predicate);
        Task<List<T>> ConsultarAsync(Expression<Func<T, bool>> predicate);
        T Procurar(params object[] key);
        Task<T> ProcurarAsync(Expression<Func<T, bool>> predicate);
        T ProcurarPor(Expression<Func<T, bool>> predicate);
        void Cadastrar(T entity);
        T CadastrarT(T entity);
        void Actualizar(T entity);
        void ActualizarCampo(T entity,string field);
        void Eliminar(Func<T, bool> predicate);
        void Commit();
        void Dispose();
        void RefreshEntity();
        long Count();
        long Count(Expression<Func<T, bool>> predicate);

    }
}
