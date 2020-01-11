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
    public class CaixaBLL : GenericFunction<caixa>
    {
        ICaixaRepository CaixaRepository_;

        public CaixaBLL()
        {
            try
            {
                CaixaRepository_ = new CaixaRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public caixa Cadastrar(caixa Caixa)
        {
            try
            {
                return CaixaRepository_.CadastrarT(Caixa);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar Caixa: " + ex.Message.ToString());
            }
        }

        public void Editar(caixa Caixa)
        {
            try
            {
                CaixaRepository_.Actualizar(Caixa);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao actualizar Caixa: " + ex.Message.ToString());
            }
        }

        public bool Eliminar(caixa Caixa)
        {
            try
            {
                CaixaRepository_.Eliminar( u => u.id_caixa == Caixa.id_caixa);
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
                CaixaRepository_.Eliminar(u => u.id_caixa == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public caixa ObterPeloId(int idEntity)
        {
            try
            {
                CaixaRepository_.RefreshEntity();
                return CaixaRepository_.ProcurarPor(t => t.id_caixa == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao obter o caixa pelo id: " + ex.Message.ToString());
            }
        }

        public caixa ObterCaixaAberto(int idUtilizador)
        {
            try
            {
                CaixaRepository_.RefreshEntity();
                var Caixa = CaixaRepository_.Consultar(t => t.id_utilizador == idUtilizador && t.data_fecho == null).OrderByDescending(t=>t.data_abertura).FirstOrDefault();
                if (Caixa != null)
                    return Caixa;
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao obter o caixa: " + ex.Message.ToString());
            }
        }

        public Task<caixa> ObterPeloIdAsync(int idEntity)
        {
            CaixaRepository_.RefreshEntity();
            return CaixaRepository_.ProcurarAsync(t => t.id_caixa == idEntity);
        }

        public List<caixa> Listar()
        {
            CaixaRepository_.RefreshEntity();
            return CaixaRepository_.ObterTodos();
        }


        public Task<List<caixa>> ListarAsync()
        {
            try
            {
                CaixaRepository_.RefreshEntity();
                return CaixaRepository_.ConsultarAsync(t => t.id_caixa > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Caixa: " + ex.Message.ToString());
            }
        }

        public caixa FecharCaixa(int idCaixa)
        {
            try
            {
                
                if (IsCaixaAberto(idCaixa))
                {
                    CaixaRepository_.RefreshEntity();
                    var Caixa = ObterPeloId(idCaixa);
                    Caixa.data_actualizacao = DateTime.Now;
                    Caixa.data_fecho = DateTime.Now;
                    VendaBLL vendaBll = new VendaBLL();
                    var ListVendaCaixa = vendaBll.ListarVendaCaixa(idCaixa);
                    double SaldoInicial = Caixa.valor_inicial;
                    double ValorTotalVenda = ListVendaCaixa.Sum(t => t.total_venda);
                    double DinheiroAdicionado = Caixa.movimento_caixa.Where(t => t.id_tipo_movimento == 1).Sum(t => t.valor_movimento);
                    double DinheiroRetirado = Caixa.movimento_caixa.Where(t => t.id_tipo_movimento == 2).Sum(t => t.valor_movimento);
                    double SaldoFinal = (ValorTotalVenda + DinheiroAdicionado + SaldoInicial) - (DinheiroRetirado);
                    Caixa.saldo = SaldoFinal;
                    CaixaRepository_.Actualizar(Caixa);
                    return Caixa;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao obter o caixa: " + ex.Message.ToString());
            }
        }

        public bool IsCaixaAberto(int idCaixa)
        {
            try
            {
                CaixaRepository_.RefreshEntity();
                var Caixa = ObterPeloId(idCaixa);
                if (Caixa != null) {
                    if (Caixa.estado_caixa.ToLower().Equals("aberto"))
                        return true;
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao verificar o estado do caixa: " + ex.Message.ToString());
            }
        }
    }
}
