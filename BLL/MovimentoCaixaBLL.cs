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
    public class MovimentoCaixaBLL : GenericFunction<movimento_caixa>
    {
        IMovimentoCaixaRepository MovimentoCaixaRepository_;
        public MovimentoCaixaBLL()
        {
            try
            {
                MovimentoCaixaRepository_ = new MovimentoCaixaRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public movimento_caixa Cadastrar(movimento_caixa MovimentoCaixa)
        {
            try
            {
                return MovimentoCaixaRepository_.CadastrarT(MovimentoCaixa);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar MovimentoCaixa: " + ex.Message.ToString());
            }
        }

        public void Editar(movimento_caixa MovimentoCaixa)
        {
            try
            {
                MovimentoCaixaRepository_.Actualizar(MovimentoCaixa);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao actualizar MovimentoCaixa: " + ex.Message.ToString());
            }
        }

        public bool Eliminar(movimento_caixa MovimentoCaixa)
        {
            try
            {
                MovimentoCaixaRepository_.Eliminar( u => u.id_movimento == MovimentoCaixa.id_movimento);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Eliminar(int idMovimento)
        {
            try
            {
                MovimentoCaixaRepository_.Eliminar(u => u.id_movimento == idMovimento);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public movimento_caixa ObterPeloId(int idMovimento)
        {
            try
            {
                return MovimentoCaixaRepository_.ProcurarPor(t => t.id_movimento == idMovimento);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar MovimentoCaixa: " + ex.Message.ToString());
            }
        }

        public Task<movimento_caixa> ObterPeloIdAsync(int idMovimento)
        {
            return MovimentoCaixaRepository_.ProcurarAsync(t => t.id_movimento == idMovimento);
        }

        public List<movimento_caixa> Listar()
        {
            return MovimentoCaixaRepository_.ObterTodos();
        }

        public Task<List<movimento_caixa>> ListarAsync()
        {
            try
            {
                return MovimentoCaixaRepository_.ConsultarAsync(t => t.id_movimento > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar MovimentoCaixa: " + ex.Message.ToString());
            }
        }

    }
}
