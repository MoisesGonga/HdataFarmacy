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
    public class EstoqueProdutoBLL : GenericFunction<estoque_produto>
    {
        IEstoqueProdutoRepository EstoqueProdutoRepository_;

        public EstoqueProdutoBLL()
        {
            try
            { 
                EstoqueProdutoRepository_ = new EstoqueProdutoRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public estoque_produto Cadastrar(estoque_produto EstoqueProduto)
        {
            try
            {

                var result = EstoqueProdutoRepository_.CadastrarT(EstoqueProduto);
                
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar EstoqueProduto: " + ex.Message.ToString());
            }
        }

        public void Editar(estoque_produto EstoqueProduto)
        {
            try
            {
                EstoqueProdutoRepository_.Actualizar(EstoqueProduto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao actualizar EstoqueProduto: " + ex.Message.ToString());
            }
        }

        public bool Eliminar(estoque_produto EstoqueProduto)
        {
            try
            {
                EstoqueProdutoRepository_.Eliminar( u => u.id_lote == EstoqueProduto.id_lote && u.id_local_estoque== EstoqueProduto.id_local_estoque);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Eliminar(int idEntity, int idLocal)
        {
            try
            {
                EstoqueProdutoRepository_.Eliminar(u => u.id_lote == idEntity && u.id_local_estoque==idLocal);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public estoque_produto ObterPeloId(int idEntity, int idLocal)
        {
            try
            {
                return EstoqueProdutoRepository_.ProcurarPor(t => t.id_lote == idEntity && t.id_local_estoque == idLocal);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar EstoqueProduto: " + ex.Message.ToString());
            }
        }
        
       
        public Task<estoque_produto> ObterPeloIdAsync(int idEntity, int idLocal)
        {
            return EstoqueProdutoRepository_.ProcurarAsync(t => t.id_lote == idEntity && t.id_local_estoque == idLocal);
        }

        public List<estoque_produto> Listar()
        {
            return EstoqueProdutoRepository_.ObterTodos();
        }

        public Task<List<estoque_produto>> ListarAsync()
        {
            try
            {
                return EstoqueProdutoRepository_.ConsultarAsync(t => t.id_lote > 0 && t.id_local_estoque > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar EstoqueProduto: " + ex.Message.ToString());
            }
        }

        public bool Eliminar(int idEntity)
        {
            throw new NotImplementedException();
        }

        public estoque_produto ObterPeloId(int idEntity)
        {
            throw new NotImplementedException();
        }

        public Task<estoque_produto> ObterPeloIdAsync(int idEntity)
        {
            throw new NotImplementedException();
        }
    }
}
