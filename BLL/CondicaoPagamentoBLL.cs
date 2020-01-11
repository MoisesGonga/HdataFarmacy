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
    public class CondicaoPagamentoBLL : GenericFunction<condicao_pagamento>
    {
        ICondicaoPagamentoRepository CondicaoPagamentoRepository_;

        public CondicaoPagamentoBLL()
        {
            try
            { 
                CondicaoPagamentoRepository_ = new CondicaoPagamentoRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public condicao_pagamento Cadastrar(condicao_pagamento CondicaoPagamento)
        {
            try
            { 
                var result = CondicaoPagamentoRepository_.CadastrarT(CondicaoPagamento);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar CondicaoPagamento: " + ex.Message.ToString());
            }
        }

        public void Editar(condicao_pagamento CondicaoPagamento)
        {
            try
            {
                CondicaoPagamentoRepository_.Actualizar(CondicaoPagamento);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao actualizar CondicaoPagamento: " + ex.Message.ToString());
            }
        }

        public bool Eliminar(condicao_pagamento CondicaoPagamento)
        {
            try
            {
                CondicaoPagamentoRepository_.Eliminar( u => u.id_condicao_pagamento == CondicaoPagamento.id_condicao_pagamento);
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
                CondicaoPagamentoRepository_.Eliminar(u => u.id_condicao_pagamento == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public condicao_pagamento ObterPeloId(int idEntity)
        {
            try
            {
                return CondicaoPagamentoRepository_.ProcurarPor(t => t.id_condicao_pagamento == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar CondicaoPagamento: " + ex.Message.ToString());
            }
        }

        public Task<condicao_pagamento> ObterPeloIdAsync(int idEntity)
        {
            return CondicaoPagamentoRepository_.ProcurarAsync(t => t.id_condicao_pagamento == idEntity);
        }

        public List<condicao_pagamento> Listar()
        {
            CondicaoPagamentoRepository_.RefreshEntity();
            return CondicaoPagamentoRepository_.ObterTodos();
        }

        public Task<List<condicao_pagamento>> ListarAsync()
        {
            try
            {
                return CondicaoPagamentoRepository_.ConsultarAsync(t => t.id_condicao_pagamento > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar CondicaoPagamento: " + ex.Message.ToString());
            }
        }
    }
}
