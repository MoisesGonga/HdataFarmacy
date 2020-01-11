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
    public class MovimentoEstoqueBLL : GenericFunction<movimento_estoque>
    {
        //ICondicaoPagamentoRepository IProdutoRepository_;
        IMovimentoEstoqueRepository IMovimentoEstoqueRepository_;

        public MovimentoEstoqueBLL()
        {
            try
            {
                IMovimentoEstoqueRepository_ = new MovimentoEstoqueRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public movimento_estoque Cadastrar(movimento_estoque t)
        {
            try
            {
                return IMovimentoEstoqueRepository_.CadastrarT(t);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar Cliente: " + ex.Message.ToString());
            }
        }

        public void Editar(movimento_estoque t)
        {
            try
            {
                IMovimentoEstoqueRepository_.Actualizar(t);
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
                IMovimentoEstoqueRepository_.Eliminar(u => u.id_movimento_estoque == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Eliminar(movimento_estoque t)
        {
           
            try
            {
                IMovimentoEstoqueRepository_.Eliminar(u => u.id_movimento_estoque == t.id_movimento_estoque);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    

        public List<movimento_estoque> Listar()
        {
            return IMovimentoEstoqueRepository_.ObterTodos();
        }

        public Task<List<movimento_estoque>> ListarAsync()
        {
            try
            {
                return IMovimentoEstoqueRepository_.ConsultarAsync(t => t.id_movimento_estoque > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        public movimento_estoque ObterPeloId(int idEntity)
        {
            try
            {
                return IMovimentoEstoqueRepository_.ProcurarPor(t => t.id_movimento_estoque == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        public Task<movimento_estoque> ObterPeloIdAsync(int idEntity)
        {
            return IMovimentoEstoqueRepository_.ProcurarAsync(t => t.id_movimento_estoque == idEntity);
        }
    }
}
