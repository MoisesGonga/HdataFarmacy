using BLL.Interfaces;
using DAL.IRepositoryEntity;
using DAL.RepositoryEntity;
using Data_Acess_Layer;
using Data_Acess_Layer.RepositoryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LocalEstoqueBLL : GenericFunction<local_estoque>
    {
        ILocalEstoqueRepository LocalEstoqueRepository_;

        public LocalEstoqueBLL()
        {
            try
            { 
                LocalEstoqueRepository_ = new LocalEstoqueRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public local_estoque Cadastrar(local_estoque LocalEstoque)
        {
            try
            {

                var result = LocalEstoqueRepository_.CadastrarT(LocalEstoque);
                
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar LocalEstoque: " + ex.Message.ToString());
            }
        }

        public void Editar(local_estoque LocalEstoque)
        {
            try
            {
                LocalEstoqueRepository_.Actualizar(LocalEstoque);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao actualizar LocalEstoque: " + ex.Message.ToString());
            }
        }

        public bool Eliminar(local_estoque LocalEstoque)
        {
            try
            {
                LocalEstoqueRepository_.Eliminar( u => u.id_local_estoque == LocalEstoque.id_local_estoque);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Eliminar(int idEntity)
        {
            try
            {
                LocalEstoqueRepository_.Eliminar(u => u.id_local_estoque == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public local_estoque ObterPeloId(int idEntity)
        {
            try
            {
                return LocalEstoqueRepository_.ProcurarPor(t => t.id_local_estoque == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar LocalEstoque: " + ex.Message.ToString());
            }
        }

        public Task<local_estoque> ObterPeloIdAsync(int idEntity)
        {
            return LocalEstoqueRepository_.ProcurarAsync(t => t.id_local_estoque == idEntity);
        }

        public List<local_estoque> Listar()
        {
            return LocalEstoqueRepository_.ObterTodos();
        }

        public Task<List<local_estoque>> ListarAsync()
        {
            try
            {
                return LocalEstoqueRepository_.ConsultarAsync(t => t.id_local_estoque > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar LocalEstoque: " + ex.Message.ToString());
            }
        }

      

    }
}
