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
    public class CategoriaProdutoBLL : GenericFunction<categoria_produto> , ICategoriaProdutoBLL
    {
       /// IClienteRepository ICategoriaProdutoRepository_;
        ICategoriaProdutoRepository ICategoriaProdutoRepository_;
        public CategoriaProdutoBLL()
        {
            try
            {
                ICategoriaProdutoRepository_ = new CategoriaProdutoRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      

      

        public categoria_produto Cadastrar(categoria_produto t)
        {
            try
            {
                return ICategoriaProdutoRepository_.CadastrarT(t);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar Cliente: " + ex.Message.ToString());
            }
        }

        public void Editar(categoria_produto t)
        {
            try
            {
                ICategoriaProdutoRepository_.Actualizar(t);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao actualizar Cliente: " + ex.Message.ToString());
            }
        }

        public bool Eliminar(categoria_produto t)
        {
            try
            {
                ICategoriaProdutoRepository_.Eliminar(u => u.id_categoria == t.id_categoria);
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
                ICategoriaProdutoRepository_.Eliminar(u => u.id_categoria == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        categoria_produto GenericFunction<categoria_produto>.ObterPeloId(int idEntity)
        {
            try
            {
                return ICategoriaProdutoRepository_.ProcurarPor(t => t.id_categoria == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        Task<categoria_produto> GenericFunction<categoria_produto>.ObterPeloIdAsync(int idEntity)
        {
            return ICategoriaProdutoRepository_.ProcurarAsync(t => t.id_categoria == idEntity);
        }

        List<categoria_produto> GenericFunction<categoria_produto>.Listar()
        {
            return ICategoriaProdutoRepository_.ObterTodos();
        }

        Task<List<categoria_produto>> GenericFunction<categoria_produto>.ListarAsync()
        {
            try
            {
                return ICategoriaProdutoRepository_.ConsultarAsync(t => t.id_categoria > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

       

        public categoria_produto ObterPeloId(int idEntity)
        {
            try
            {
                return ICategoriaProdutoRepository_.ProcurarPor(t => t.id_categoria == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar CondicaoPagamento: " + ex.Message.ToString());
            }
        }

        public Task<categoria_produto> ObterPeloIdAsync(int idEntity)
        {
            return ICategoriaProdutoRepository_.ProcurarAsync(t => t.id_categoria == idEntity);
        }

        public List<categoria_produto> Listar()
        {
            return ICategoriaProdutoRepository_.ObterTodos();
        }

        public Task<List<categoria_produto>> ListarAsync()
        {
            try
            {
                return ICategoriaProdutoRepository_.ConsultarAsync(t => t.id_categoria > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar CondicaoPagamento: " + ex.Message.ToString());
            }
        }
    }
}
