using BLL.Interfaces;
using DAL.IRepositoryEntity;
using DAL.RepositoryEntity;
using Data_Acess_Layer.RepositoryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UtilizadorBLL : GenericFunction<utilizador>
    {
        IUtilizadorRepository UtilizadorRepository_;
        public UtilizadorBLL()
        {
            try
            {
                UtilizadorRepository_ = new UtilizadorRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public utilizador Cadastrar(utilizador Utilizador)
        {
            try
            {
                return UtilizadorRepository_.CadastrarT(Utilizador);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao cadastrar Utilizador: " + ex.Message.ToString());
            }
        }

        public void Editar(utilizador Utilizador)
        {
            try
            {
                UtilizadorRepository_.Actualizar(Utilizador);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao actualizar Utilizador: " + ex.Message.ToString());
            }
        }

        public bool Eliminar(utilizador Utilizador)
        {
            try
            {
                UtilizadorRepository_.Eliminar( u => u.id_utilizador == Utilizador.id_utilizador);
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
                
                UtilizadorRepository_.Eliminar(u => u.id_utilizador == idEntity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public utilizador ObterPeloId(int idEntity)
        {
            try
            {
                UtilizadorRepository_.RefreshEntity();
                return UtilizadorRepository_.ProcurarPor(t => t.id_utilizador == idEntity);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao obter o utilizador pelo id: " + ex.Message.ToString());
            }
        }

        public Task<utilizador> ObterPeloIdAsync(int idEntity)
        {
            UtilizadorRepository_.RefreshEntity();
            return UtilizadorRepository_.ProcurarAsync(t => t.id_utilizador == idEntity);
        }

        public List<utilizador> Listar()
        {
            UtilizadorRepository_.RefreshEntity();
            return UtilizadorRepository_.ObterTodos();
        }

        public Task<List<utilizador>> ListarAsync()
        {
            try
            {
                UtilizadorRepository_.RefreshEntity();
                return UtilizadorRepository_.ConsultarAsync(t => t.id_utilizador > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu uma excepção ao listar Utilizador: " + ex.Message.ToString());
            }
        }

        public async Task<utilizador> Login(string Username, string Password)
        {
            try
            {
                UtilizadorRepository_.RefreshEntity();
                return await UtilizadorRepository_.ProcurarAsync(q => q.username == Username && q.password == Password);
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro ao efectuar o login.");
            }
        }
    }
}
