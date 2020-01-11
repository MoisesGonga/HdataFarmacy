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
    public class TipoUnidadeBLL : GenericFunction<tipo_unidade>
    {
        //ICondicaoPagamentoRepository ITipoUnidadeRepository_;
        ITipoUnidadeRepository ITipoUnidadeRepository_;

        public TipoUnidadeBLL()
        {
            try
            { 
                ITipoUnidadeRepository_ = new TipoUnidadeRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tipo_unidade Cadastrar(tipo_unidade t)
        {
            try
            {
                return ITipoUnidadeRepository_.CadastrarT(t);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar Cliente: " + ex.Message.ToString());
            }
        }

        public void Editar(tipo_unidade t)
        {
            try
            {
                ITipoUnidadeRepository_.Actualizar(t);
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
                ITipoUnidadeRepository_.Eliminar(u => u.id_tipo_unidade == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Eliminar(tipo_unidade t)
        {
           
            try
            {
                ITipoUnidadeRepository_.Eliminar(u => u.id_tipo_unidade == t.id_tipo_unidade);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    

        public List<tipo_unidade> Listar()
        {
            return ITipoUnidadeRepository_.ObterTodos();
        }

        public Task<List<tipo_unidade>> ListarAsync()
        {
            try
            {
                return ITipoUnidadeRepository_.ConsultarAsync(t => t.id_tipo_unidade > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        public tipo_unidade ObterPeloId(int idEntity)
        {
            try
            {
                return ITipoUnidadeRepository_.ProcurarPor(t => t.id_tipo_unidade == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        public Task<tipo_unidade> ObterPeloIdAsync(int idEntity)
        {
            return ITipoUnidadeRepository_.ProcurarAsync(t => t.id_tipo_unidade == idEntity);
        }
    }
}
