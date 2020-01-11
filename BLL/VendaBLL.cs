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
    public class VendaBLL : GenericFunction<venda>
    {
        IVendaRepository VendaRepository_;
        TipoDocVendaBLL tipoDocVendaBLL;

        public VendaBLL()
        {
            try
            {
                VendaRepository_ = new VendaRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public venda Cadastrar(venda Venda)
        {
            try
            {
                

                var result = VendaRepository_.CadastrarT(Venda);
                // Incrementar documento de Venda
                tipoDocVendaBLL = new TipoDocVendaBLL();
                tipoDocVendaBLL.IncrementarNumeroDocVenda(Venda.id_tipo_documento);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar Venda: " + ex.Message.ToString());
            }
        }

        public void Editar(venda Venda)
        {
            try
            {
                VendaRepository_.Actualizar(Venda);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao actualizar Venda: " + ex.Message.ToString());
            }
        }

        public bool Eliminar(venda Venda)
        {
            try
            {
                VendaRepository_.Eliminar( u => u.id_venda == Venda.id_venda);
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
                VendaRepository_.Eliminar(u => u.id_venda == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public venda ObterPeloId(int idEntity)
        {
            try
            {
                return VendaRepository_.ProcurarPor(t => t.id_venda == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Venda: " + ex.Message.ToString());
            }
        }

        public Task<venda> ObterPeloIdAsync(int idEntity)
        {
            return VendaRepository_.ProcurarAsync(t => t.id_venda == idEntity);
        }

        public List<venda> Listar()
        {
            return VendaRepository_.ObterTodos();
        }

        public Task<List<venda>> ListarAsync()
        {
            try
            {
                return VendaRepository_.ConsultarAsync(t => t.id_venda > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Venda: " + ex.Message.ToString());
            }
        }

        public Task<List<venda>> ListarVendaCaixaAsync(int idCaixa)
        {
            try
            {
                return VendaRepository_.ConsultarAsync(t => t.id_venda > 0 && t.id_caixa== idCaixa);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Venda: " + ex.Message.ToString());
            }
        }

        public List<venda> ListarVendaCaixa(int idCaixa)
        {
            try
            {
                return VendaRepository_.Consultar(t => t.id_venda > 0 && t.id_caixa == idCaixa);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Venda: " + ex.Message.ToString());
            }
        }

    }
}
