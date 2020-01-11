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
    public class ProdutoBLL : GenericFunction<produto>
    {
        //ICondicaoPagamentoRepository IProdutoRepository_;
        IProdutoRepository IProdutoRepository_;

        public ProdutoBLL()
        {
            try
            { 
                IProdutoRepository_ = new ProdutoRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public produto Cadastrar(produto t)
        {
            try
            {
                return IProdutoRepository_.CadastrarT(t);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar Produto: " + ex.Message.ToString());
            }
        }

        public void Editar(produto t)
        {
            try
            {
                IProdutoRepository_.Actualizar(t);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao actualizar Produto: " + ex.Message.ToString());
            }
        }

        public bool Eliminar(int idEntity)
        {
            try
            {
                IProdutoRepository_.Eliminar(u => u.id_produto == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Eliminar(produto t)
        {
           
            try
            {
                IProdutoRepository_.Eliminar(u => u.id_produto == t.id_produto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    

        public List<produto> Listar()
        {
            var result = IProdutoRepository_.ObterTodos();
            return result;
        }

        public Task<List<produto>> ListarAsync()
        {
            try
            {
                return IProdutoRepository_.ConsultarAsync(t => t.id_produto > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Produto: " + ex.Message.ToString());
            }
        }

        public produto ObterPeloId(int idProduto)
        {
            try
            {
                IProdutoRepository_.RefreshEntity();
                return IProdutoRepository_.ProcurarPor(t => t.id_produto == idProduto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Produto: " + ex.Message.ToString());
            }
        }

        public lote ObterLotePeloCodBarras(string CodBarras)
        {
            try
            {
                LoteBLL loteBLL = new LoteBLL();
                return loteBLL.ObterLoteCodBarra(CodBarras);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Produto: " + ex.Message.ToString());
            }
        }

        public lote ObterLoteRecenteProduto(int idProduto)
        {
            try
            {
                IProdutoRepository_.RefreshEntity();
                var lotes = IProdutoRepository_.ProcurarPor(t => t.id_produto == idProduto).lotes;
                return lotes.OrderBy(t => t.data_validade).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao obter lote com validade mais recente: " + ex.Message.ToString());
            }
        }

        public lote ObterLoteAntigoProduto(int idProduto)
        {
            try
            {
                IProdutoRepository_.RefreshEntity();
                var lotes = IProdutoRepository_.ProcurarPor(t => t.id_produto == idProduto).lotes;
                return lotes.OrderByDescending(t => t.data_validade).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao obter lote com validade mais antiga: " + ex.Message.ToString());
            }
        }

        public Task<produto> ObterPeloIdAsync(int idEntity)
        {
            return IProdutoRepository_.ProcurarAsync(t => t.id_produto == idEntity);
        }
    }
}
