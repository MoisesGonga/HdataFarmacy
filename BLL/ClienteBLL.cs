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
    public class ClienteBLL : GenericFunction<cliente>,IClienteBLL
    {
        IClienteRepository ClienteRepository_;
        public ClienteBLL()
        {
            try
            {
                ClienteRepository_ = new ClienteRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public cliente Cadastrar(cliente Cliente)
        {
            try
            {
                return ClienteRepository_.CadastrarT(Cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar Cliente: " + ex.Message.ToString());
            }
        }

        public void Editar(cliente Cliente)
        {
            try
            {
                ClienteRepository_.Actualizar(Cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao actualizar Cliente: " + ex.Message.ToString());
            }
        }

        public bool Eliminar(cliente Cliente)
        {
            try
            {
                ClienteRepository_.Eliminar( u => u.id_cliente == Cliente.id_cliente);
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
                ClienteRepository_.Eliminar(u => u.id_cliente == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public cliente ObterPeloId(int idEntity)
        {
            try
            {
                return ClienteRepository_.ProcurarPor(t => t.id_cliente == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        public Task<cliente> ObterPeloIdAsync(int idEntity)
        {
            return ClienteRepository_.ProcurarAsync(t => t.id_cliente == idEntity);
        }

        public List<cliente> Listar()
        {
            return ClienteRepository_.ObterTodos();
        }

        public Task<List<cliente>> ListarAsync()
        {
            try
            {
                return ClienteRepository_.ConsultarAsync(t => t.id_cliente > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Cliente: " + ex.Message.ToString());
            }
        }

        public cliente ClienteDiverso()
        {
            try
            {
                return ClienteRepository_.Procurar(1);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao obter Cliente Diverso: " + ex.Message.ToString());
            }
        }

    }
}
