using BLL;
using HDATA_PHARMACY.Views.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace HDATA_PHARMACY.Views.Fornecedor
{
    /// <summary>
    /// Interaction logic for FornecedorAdicionar_UC.xaml
    /// </summary>
    public partial class FornecedorAdicionar_UC : UserControl
    {
        LoteAdicionar_UC LoteAdicionar_UC;
        public FornecedorAdicionar_UC()
        {
            InitializeComponent();
        }
        public FornecedorAdicionar_UC(LoteAdicionar_UC LoteAdicionar_UC)
        {
            InitializeComponent();


            this.LoteAdicionar_UC = LoteAdicionar_UC;


        }
        private void btn_salvar_Click(object sender, RoutedEventArgs e)
        {
            SalvarCliente();
            MessageBox.Show("Salvo!");
            if (LoteAdicionar_UC != null)
            {
                LoteAdicionar_UC.CarregarDados();
            }
        }


        private void SalvarCliente()
        {
            string nome = TxtNome.Text;
            string endereco = TxtEndereco.Text;
            string telefone = TxtTelefone.Text;
            string bi = TxtBI.Text;
            string emai = TxtEmail.Text;

            fornecedor ci = new fornecedor();
            ci.nif = bi;
            ci.nome = nome;
            ci.telefone = telefone;
            ci.endereco = endereco;
            ci.email = emai;

           
            FornecedorBLL cibll = new  FornecedorBLL();
            cibll.Cadastrar(ci);
         



        }
    }
}
