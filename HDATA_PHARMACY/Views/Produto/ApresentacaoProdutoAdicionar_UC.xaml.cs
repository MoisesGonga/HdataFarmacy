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

namespace HDATA_PHARMACY.Views.Produto
{
    /// <summary>
    /// Interaction logic for ApresentacaoProdutoAdicionar_UC.xaml
    /// </summary>
    public partial class ApresentacaoProdutoAdicionar_UC : UserControl
    {
        LoteAdicionar_UC LoteAdicionar_UC;
        public ApresentacaoProdutoAdicionar_UC()
        {
            InitializeComponent();
        }
        public ApresentacaoProdutoAdicionar_UC(LoteAdicionar_UC LoteAdicionar_UC)
        {
            InitializeComponent();

          
            this.LoteAdicionar_UC = LoteAdicionar_UC;


        }
    private void btn_salvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                salvar();
                MessageBox.Show("salvo");
                LoteAdicionar_UC.CarregarDados();


            }
            catch (Exception)
            {
                throw;
            }


        }
        private void salvar()
        {
            string nome = TxtNome.Text;
           


            apresentacao_produto prod_ = new apresentacao_produto();
            prod_.nome = nome;
          
            

            ApresentacaoProdutoBLL produtoBLL_ = new ApresentacaoProdutoBLL();
            produtoBLL_.Cadastrar(prod_);

        }
    }
}
