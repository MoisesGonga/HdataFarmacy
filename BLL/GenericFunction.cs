using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface GenericFunction<T>
    {
        T Cadastrar(T t);
        void Editar(T t);
        bool Eliminar(T t);
        bool Eliminar(int idEntity);
        T ObterPeloId(int idEntity);
        Task<T> ObterPeloIdAsync(int idEntity);
        List<T> Listar();
        Task<List<T>> ListarAsync();
    }
}
