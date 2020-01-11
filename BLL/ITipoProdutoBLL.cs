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
    public class ITipoProdutoBLL : GenericFunction<tipo_produto>
    {
        //ICondicaoPagamentoRepository ITipoProdutoRepository_;
        ITipoProdutoRepository ITipoProdutoRepository_;

        public ITipoProdutoBLL()
        {
            try
            { 
                ITipoProdutoRepository_ = new TipoProdutoRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tipo_produto Cadastrar(tipo_produto t)
        {
            try
            {
                return ITipoProdutoRepository_.CadastrarT(t);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar Cliente: " + ex.Message.ToString());
            }
        }

        public void Editar(tipo_produto t)
        {
            try
            {
                ITipoProdutoRepository_.Actualizar(t);
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
                ITipoProdutoRepository_.Eliminar(u => u.id_tipo_produto == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Eliminar(tipo_produto t)
        {
           
            try
            {
                ITipoProdutoRepository_.Eliminar(u => u.id_tipo_produto == t.id_tipo_produto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    

        public List<tipo_produto> Listar()
        {
            return ITipoProdutoRepository_.ObterTodos();
        }

        public Task<List<tipo_produto>> ListarAsync()
        {
            try
            {
                return ITipoProdutoRepository_.ConsultarAsync(t => t.id_tipo_produto > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        public tipo_produto ObterPeloId(int idEntity)
        {
            try
            {
                return ITipoProdutoRepository_.ProcurarPor(t => t.id_tipo_produto == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        public Task<tipo_produto> ObterPeloIdAsync(int idEntity)
        {
            return ITipoProdutoRepository_.ProcurarAsync(t => t.id_tipo_produto == idEntity);
        }
    }
}
