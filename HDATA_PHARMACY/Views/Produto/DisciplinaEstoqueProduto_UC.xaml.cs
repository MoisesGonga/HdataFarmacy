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
    /// Interaction logic for DisciplinaEstoqueProduto_UC.xaml
    /// </summary>
    public partial class DisciplinaEstoqueProduto_UC : UserControl
    {
        ProdutoAdicionar_UC  ProdutoAdicionar_UC;
        public DisciplinaEstoqueProduto_UC(ProdutoAdicionar_UC ProdutoAdicionar_UC)
        {
            InitializeComponent();


            this.ProdutoAdicionar_UC = ProdutoAdicionar_UC;


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


            disciplina_estoque prod_ = new disciplina_estoque();
            prod_.nome = nome;
            prod_.codigo_disciplina = Convert.ToInt32( designacao);

            //  prod_.

            DisciplinaEstoqueBLL produtoBLL_ = new DisciplinaEstoqueBLL();
            produtoBLL_.Cadastrar(prod_);

        }
    }
}
