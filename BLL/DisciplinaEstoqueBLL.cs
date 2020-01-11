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
    public class DisciplinaEstoqueBLL : GenericFunction<disciplina_estoque>
    {
        //ICondicaoPagamentoRepository IDisciplinaEstoqueRepository_;
        IDisciplinaEstoqueRepository IDisciplinaEstoqueRepository_;

        public DisciplinaEstoqueBLL()
        {
            try
            { 
                IDisciplinaEstoqueRepository_ = new DisciplinaEstoqueRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public disciplina_estoque Cadastrar(disciplina_estoque t)
        {
            try
            {
                return IDisciplinaEstoqueRepository_.CadastrarT(t);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar Cliente: " + ex.Message.ToString());
            }
        }

        public void Editar(disciplina_estoque t)
        {
            try
            {
                IDisciplinaEstoqueRepository_.Actualizar(t);
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
                IDisciplinaEstoqueRepository_.Eliminar(u => u.id_disciplina_estoque == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Eliminar(disciplina_estoque t)
        {
           
            try
            {
                IDisciplinaEstoqueRepository_.Eliminar(u => u.id_disciplina_estoque == t.id_disciplina_estoque);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    

        public List<disciplina_estoque> Listar()
        {
            return IDisciplinaEstoqueRepository_.ObterTodos();
        }

        public Task<List<disciplina_estoque>> ListarAsync()
        {
            try
            {
                return IDisciplinaEstoqueRepository_.ConsultarAsync(t => t.id_disciplina_estoque > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        public disciplina_estoque ObterPeloId(int idEntity)
        {
            try
            {
                return IDisciplinaEstoqueRepository_.ProcurarPor(t => t.id_disciplina_estoque == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        public Task<disciplina_estoque> ObterPeloIdAsync(int idEntity)
        {
            return IDisciplinaEstoqueRepository_.ProcurarAsync(t => t.id_disciplina_estoque == idEntity);
        }
    }
}
