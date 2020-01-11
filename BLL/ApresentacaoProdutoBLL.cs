using BLL.Interfaces;
using DAL.IRepositoryEntity;
using DAL.RepositoryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ApresentacaoProdutoBLL : GenericFunction<apresentacao_produto>
    {
        //ICondicaoPagamentoRepository IApresentacaoProdutoRepository_;
        IApresentacaoProdutoRepository IApresentacaoProdutoRepository_;

        public ApresentacaoProdutoBLL()
        {
            try
            { 
                IApresentacaoProdutoRepository_ = new ApresentacaoProdutoRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public apresentacao_produto Cadastrar(apresentacao_produto t)
        {
            try
            {
                return IApresentacaoProdutoRepository_.CadastrarT(t);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar Cliente: " + ex.Message.ToString());
            }
        }

        public void Editar(apresentacao_produto t)
        {
            try
            {
                IApresentacaoProdutoRepository_.Actualizar(t);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao actualizar Cliente: " + ex.Message.ToString());
            }
        }

        public bool Eliminar(int idEntity)
        {
            try
            {
                IApresentacaoProdutoRepository_.Eliminar(u => u.id_apresentacao_produto == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Eliminar(apresentacao_produto t)
        {
           
            try
            {
                IApresentacaoProdutoRepository_.Eliminar(u => u.id_apresentacao_produto == t.id_apresentacao_produto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    

        public List<apresentacao_produto> Listar()
        {
            return IApresentacaoProdutoRepository_.ObterTodos();
        }

        public Task<List<apresentacao_produto>> ListarAsync()
        {
            try
            {
                return IApresentacaoProdutoRepository_.ConsultarAsync(t => t.id_apresentacao_produto > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        public apresentacao_produto ObterPeloId(int idEntity)
        {
            try
            {
                return IApresentacaoProdutoRepository_.ProcurarPor(t => t.id_apresentacao_produto == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        public Task<apresentacao_produto> ObterPeloIdAsync(int idEntity)
        {
            return IApresentacaoProdutoRepository_.ProcurarAsync(t => t.id_apresentacao_produto == idEntity);
        }
    }
}
