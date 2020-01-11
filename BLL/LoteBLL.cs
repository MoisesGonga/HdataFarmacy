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
    public class LoteBLL : GenericFunction<lote>
    {
        //ICondicaoPagamentoRepository ILoteRepository_;
        ILoteRepository ILoteRepository_;

        public LoteBLL()
        {
            try
            { 
                ILoteRepository_ = new LoteRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public lote Cadastrar(lote t)
        {
            try
            {
                return ILoteRepository_.CadastrarT(t);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar Lote: " + ex.Message.ToString());
            }
        }

        public void Editar(lote t)
        {
            try
            {
                ILoteRepository_.Actualizar(t);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao actualizar Lote: " + ex.Message.ToString());
            }
        }

        public bool Eliminar(int idEntity)
        {
            try
            {
                ILoteRepository_.Eliminar(u => u.id_lote == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Eliminar(lote  t)
        {
           
            try
            {
                ILoteRepository_.Eliminar(u => u.id_lote == t.id_lote);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    

        public List<lote> Listar()
        {
            return ILoteRepository_.ObterTodos();
        }

        public Task<List<lote>> ListarAsync()
        {
            try
            {
                return ILoteRepository_.ConsultarAsync(t => t.id_lote > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Lote: " + ex.Message.ToString());
            }
        }

        public lote ObterPeloId(int idEntity)
        {
            try
            {
                return ILoteRepository_.ProcurarPor(t => t.id_lote == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao obter Lote: " + ex.Message.ToString());
            }
        }

        public Task<lote> ObterPeloIdAsync(int idEntity)
        {
            return ILoteRepository_.ProcurarAsync(t => t.id_lote == idEntity);
        }

        public List<lote> ConsultarLotesCodBarra(string codigoBarras)
        {
            return ILoteRepository_.Consultar(t=>t.codigo_barra.ToLower().Equals(codigoBarras.ToLower()));
        }

        public lote ObterLoteCodBarra(string codigoBarras)
        {
            return ILoteRepository_.ProcurarPor(t => t.codigo_barra.ToLower().Equals(codigoBarras.ToLower()));
        }
    }
}
