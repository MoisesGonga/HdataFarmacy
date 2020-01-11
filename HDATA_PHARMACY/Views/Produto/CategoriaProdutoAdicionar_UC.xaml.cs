using BLL;
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
    /// Interaction logic for ProdutoAdicionar_UC.xaml
    /// </summary>
    public partial class CategoriaProdutoAdicionar_UC : UserControl
    {
        ProdutoAdicionar_UC ProdutoAdicionar_UC;
        public CategoriaProdutoAdicionar_UC(ProdutoAdicionar_UC ProdutoAdicionar_UC)
        {
            InitializeComponent();
           
            BoquearConteudo();
            this.ProdutoAdicionar_UC = ProdutoAdicionar_UC;


        }
        private void BoquearConteudo()
        {
            
        }
      
      

       
        private void btn_salvar_Click(object sender, RoutedEventArgs e)
        { 
           try
            {
                salvar();
                MessageBox.Show("salvo");
                ProdutoAdicionar_UC.CarregarDados();


            }
            catch (Exception)
            {
                throw;
            }
           
        
        }
        private void salvar()
        {
            string nome = TxtNome.Text;
            string designacao = TxtDesignacao.Text;
            string taxa_iva=TxtTaxaIva.Text;
            string notas = TxtNotas.Text;
            
            categoria_produto prod_ = new categoria_produto();
            prod_.nome = nome;
            prod_.designacao = designacao;
            prod_.notas = notas;
          //  prod_.
          
            CategoriaProdutoBLL produtoBLL_ = new CategoriaProdutoBLL();
            produtoBLL_.Cadastrar(prod_);
            
        }

        private void BttAdicionar_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
