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
    public class FornecedorBLL : GenericFunction<fornecedor>
    {
        //ICondicaoPagamentoRepository IProdutoRepository_;
        IFornecedorRepository IProdutoRepository_;

        public FornecedorBLL()
        {
            try
            { 
                IProdutoRepository_ = new FornecedorRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public fornecedor Cadastrar(fornecedor t)
        {
            try
            {
                return IProdutoRepository_.CadastrarT(t);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar Cliente: " + ex.Message.ToString());
            }
        }

        public void Editar(fornecedor t)
        {
            try
            {
                IProdutoRepository_.Actualizar(t);
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
                IProdutoRepository_.Eliminar(u => u.id_fornecedor == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Eliminar(fornecedor t)
        {
           
            try
            {
                IProdutoRepository_.Eliminar(u => u.id_fornecedor == t.id_fornecedor);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    

        public List<fornecedor> Listar()
        {
            return IProdutoRepository_.ObterTodos();
        }

        public Task<List<fornecedor>> ListarAsync()
        {
            try
            {
                return IProdutoRepository_.ConsultarAsync(t => t.id_fornecedor > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        public fornecedor ObterPeloId(int idEntity)
        {
            try
            {
                return IProdutoRepository_.ProcurarPor(t => t.id_fornecedor == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        public Task<fornecedor> ObterPeloIdAsync(int idEntity)
        {
            return IProdutoRepository_.ProcurarAsync(t => t.id_fornecedor == idEntity);
        }
    }
}
