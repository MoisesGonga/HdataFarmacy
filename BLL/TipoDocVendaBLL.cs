using BLL.Interfaces;
using DAL.IRepositoryEntity;
using DAL.RepositoryEntity;
using Data_Acess_Layer;
using Data_Acess_Layer.RepositoryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TipoDocVendaBLL : GenericFunction<tipo_doc_venda>
    {
        ITipoDocVendaRepository TipoDocVendaRepository_;

        public TipoDocVendaBLL()
        {
            try
            { 
                TipoDocVendaRepository_ = new TipoDocVendaRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public tipo_doc_venda Cadastrar(tipo_doc_venda TipoDocVenda)
        {
            try
            {

                var result = TipoDocVendaRepository_.CadastrarT(TipoDocVenda);
                
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar TipoDocVenda: " + ex.Message.ToString());
            }
        }

        public void Editar(tipo_doc_venda TipoDocVenda)
        {
            try
            {
                TipoDocVendaRepository_.Actualizar(TipoDocVenda);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao actualizar TipoDocVenda: " + ex.Message.ToString());
            }
        }

        public bool Eliminar(tipo_doc_venda TipoDocVenda)
        {
            try
            {
                TipoDocVendaRepository_.Eliminar( u => u.id_tipo_doc_venda == TipoDocVenda.id_tipo_doc_venda);
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
                TipoDocVendaRepository_.Eliminar(u => u.id_tipo_doc_venda == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public tipo_doc_venda ObterPeloId(int idEntity)
        {
            try
            {
                return TipoDocVendaRepository_.ProcurarPor(t => t.id_tipo_doc_venda == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar TipoDocVenda: " + ex.Message.ToString());
            }
        }

        public Task<tipo_doc_venda> ObterPeloIdAsync(int idEntity)
        {
            return TipoDocVendaRepository_.ProcurarAsync(t => t.id_tipo_doc_venda == idEntity);
        }

        public List<tipo_doc_venda> Listar()
        {
            return TipoDocVendaRepository_.ObterTodos();
        }

        public Task<List<tipo_doc_venda>> ListarAsync()
        {
            try
            {
                return TipoDocVendaRepository_.ConsultarAsync(t => t.id_tipo_doc_venda > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar TipoDocVenda: " + ex.Message.ToString());
            }
        }

        public bool IncrementarNumeroDocVenda(int idTipoDocVenda)
        {
            TipoDocVendaRepository_.RefreshEntity();
            var TipoDocVenda = TipoDocVendaRepository_.Procurar(idTipoDocVenda);
            if (TipoDocVenda == null)
                return false;
            TipoDocVenda.num_doc += 1;
                return true;
        }

        public bool ReiniciarNumeroDocVenda(int idTipoDocVenda)
        {
            TipoDocVendaRepository_.RefreshEntity();
            var TipoDocVenda = TipoDocVendaRepository_.Procurar(idTipoDocVenda);
            if (TipoDocVenda == null)
                return false;
                TipoDocVenda.num_doc = 1;
            return true;
        }

    }
}
