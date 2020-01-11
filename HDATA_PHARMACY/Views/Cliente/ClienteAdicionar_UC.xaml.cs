using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HDATA_PHARMACY.Views.Cliente
{
    /// <summary>
    /// Interaction logic for ClienteAdicionar_UC.xaml
    /// </summary>
    public partial class ClienteAdicionar_UC : UserControl
    {
        public ClienteAdicionar_UC()
        {
            InitializeComponent();
        }

        private void btn_salvar_Click(object sender, RoutedEventArgs e)
        {
            SalvarCliente();
        }

     
        private  void SalvarCliente()
        {
            string nome = TxtNome.Text;
            string endereco = TxtEndereco.Text;
            string telefone = TxtTelefone.Text;
            string bi = TxtBI.Text;
            string emai = TxtEmail.Text;

            cliente ci = new cliente();
            ci.bi = bi;
            ci.nome = nome;
            ci.telefone = telefone;
            ci.endereco = endereco;
            ci.email = emai;

           /* if (validar(ci)) {*/ 
            ClienteBLL cibll =new ClienteBLL();
            cibll.Cadastrar(ci);
            MessageBox.Show("Cliente salvo com sucesso");

          /*  }
            else
            {
                MessageBox.Show( "erro");
            }

            /**/
                        


        }
        /*private Boolean validar(cliente ci)
        {
            if (IsValidEmailAddress(ci.email))
            {
                return false;
            }
            else if (IsValidName(ci.nome))
            {
                return false;
            }

            return true;

        }

        private bool IsValidPhoneNmbers(this string s)
        {
            Regex regex = new Regex(@"^[0-9]*$");
            return regex.IsMatch(s);
        }
        private bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
        private bool IsValidName(this string s)
        {

            Regex regex = new Regex(@"^[\p{L}\p{M}' \.\-]+$");
            return regex.IsMatch(s);
        }*/

    }
}
