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
    public class TipoMovimentoBLL : GenericFunction<tipo_movimento>
    {
        //ICondicaoPagamentoRepository ITipoMovimentoRepository_;
        ITipoMovimentoRepository ITipoMovimentoRepository_;

        public TipoMovimentoBLL()
        {
            try
            { 
                ITipoMovimentoRepository_ = new TipoMovimentoRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tipo_movimento Cadastrar(tipo_movimento t)
        {
            try
            {
                return ITipoMovimentoRepository_.CadastrarT(t);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar Cliente: " + ex.Message.ToString());
            }
        }

        public void Editar(tipo_movimento t)
        {
            try
            {
                ITipoMovimentoRepository_.Actualizar(t);
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
                ITipoMovimentoRepository_.Eliminar(u => u.id_tipo_movimento == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Eliminar(tipo_movimento t)
        {
           
            try
            {
                ITipoMovimentoRepository_.Eliminar(u => u.id_tipo_movimento == t.id_tipo_movimento);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    

        public List<tipo_movimento> Listar()
        {
            return ITipoMovimentoRepository_.ObterTodos();
        }

        public Task<List<tipo_movimento>> ListarAsync()
        {
            try
            {
                return ITipoMovimentoRepository_.ConsultarAsync(t => t.id_tipo_movimento > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        public tipo_movimento ObterPeloId(int idEntity)
        {
            try
            {
                return ITipoMovimentoRepository_.ProcurarPor(t => t.id_tipo_movimento == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        public Task<tipo_movimento> ObterPeloIdAsync(int idEntity)
        {
            return ITipoMovimentoRepository_.ProcurarAsync(t => t.id_tipo_movimento == idEntity);
        }
    }
}
