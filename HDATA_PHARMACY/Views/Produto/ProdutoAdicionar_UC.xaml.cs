using BLL;
using HDATA_PHARMACY.Extras;
using HDATA_PHARMACY.Views.Fornecedor;
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
    public partial class ProdutoAdicionar_UC : UserControl
    {
        LoteAdicionar_UC  LoteAdicionar_UC;
        public ProdutoAdicionar_UC()
        {
            InitializeComponent();
            CarregarDados();
        }
        public ProdutoAdicionar_UC(LoteAdicionar_UC LoteAdicionar_UC)
        {
            InitializeComponent();

            CarregarDados();
            this.LoteAdicionar_UC = LoteAdicionar_UC;


        }
        public void CarregarDados()
        {

            CarregarCategoria();
            CarregarTipoUnidade();
            CarregarTipoProduto();
            CarregarDisciplinaEstoque();

        }

        private void CarregarCategoria()
        {
            
            CategoriaProdutoBLL condicaoPagamentoBll = new CategoriaProdutoBLL();
            Cmb_Categoria.DisplayMemberPath = "nome";
            Cmb_Categoria.ItemsSource = null;
            Cmb_Categoria.ItemsSource = condicaoPagamentoBll.Listar();
            
        }

        private void CarregarTipoUnidade()
        {

            TipoUnidadeBLL condicaoPagamentoBll = new TipoUnidadeBLL();
            Cmb_Unidade.DisplayMemberPath = "descricao";
            Cmb_Unidade.ItemsSource = null;
            Cmb_Unidade.ItemsSource = condicaoPagamentoBll.Listar();

        }

        private void CarregarTipoProduto()
        {

            TipoProdutoBLL condicaoPagamentoBll = new TipoProdutoBLL();
            Cmb_TipoProduto.DisplayMemberPath = "descricao";
            Cmb_TipoProduto.ItemsSource = null;
            Cmb_TipoProduto.ItemsSource = condicaoPagamentoBll.Listar();

        }

        private void CarregarDisciplinaEstoque()
        {

            DisciplinaEstoqueBLL condicaoPagamentoBll = new DisciplinaEstoqueBLL();
            Cmb_DisciplinaEstoque.DisplayMemberPath = "nome";
            Cmb_DisciplinaEstoque.ItemsSource = null;
            Cmb_DisciplinaEstoque.ItemsSource = condicaoPagamentoBll.Listar();

        }


        private void btn_salvar_Click(object sender, RoutedEventArgs e)
        {
            Salvar();


            if (LoteAdicionar_UC!=null)
            {
                LoteAdicionar_UC.CarregarDados();

            }
        }
        private void Salvar()
        {
          //  try
          //  {
                produto NovoProduto = new produto();
                NovoProduto.categoria_produto = Cmb_Categoria.SelectedItem as categoria_produto;
                NovoProduto.data_alteracao = DateTime.Now;
                NovoProduto.nome = TxtNome.Text;
                NovoProduto.descricao = TxtDescricao.Text;
                NovoProduto.tipo_produto = Cmb_TipoProduto.SelectedItem as tipo_produto;
                NovoProduto.disciplina_estoque = Cmb_DisciplinaEstoque.SelectedItem as disciplina_estoque;
                NovoProduto.codigo_barra = "";
                NovoProduto.tipo_unidade = Cmb_Unidade.SelectedItem as tipo_unidade;
                ProdutoBLL ProdutoBLL =new  ProdutoBLL();
                ProdutoBLL.Cadastrar(NovoProduto);

                MessageBox.Show("Produto Salvo com Sucesso");
         /*   }
            catch (Exception Ex)
            {

                MessageBox.Show("Erro ao salvar \n" + Ex.Message);
            }
            */
           
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_novo_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void btn_addCategoria_Click(object sender, RoutedEventArgs e)
        {
            SearchContent_Window window = new SearchContent_Window();
            CategoriaProdutoAdicionar_UC listaUC = new CategoriaProdutoAdicionar_UC(this);
            window.Title = "Adicionar de Categoria";
            window.Content = listaUC;
            window.ShowDialog();
           // CarregarCliente(listaUC.SeleccionarCliente());
        }

        private void btn_TipoUnidade_Click(object sender, RoutedEventArgs e)
        {
            SearchContent_Window window = new SearchContent_Window();
            TipoUnidadeProdutoAdicionar_UC listaUC = new TipoUnidadeProdutoAdicionar_UC(this );
            window.Title = "Adicionar Unidade";
            window.Content = listaUC;
            window.ShowDialog();
            //CarregarCliente(listaUC.SeleccionarCliente());
        }

        private void btn_TipoProduto_Click(object sender, RoutedEventArgs e)
        {
            SearchContent_Window window = new SearchContent_Window();
            TipoProdutoAdicionar_UC listaUC = new TipoProdutoAdicionar_UC(this);
            window.Title = "Adicionar Tipo de Produto";
            window.Content = listaUC;
            window.ShowDialog();
        }

        private void btn_Disciplina_Click(object sender, RoutedEventArgs e)
        {
            SearchContent_Window window = new SearchContent_Window();
            DisciplinaEstoqueProduto_UC listaUC = new DisciplinaEstoqueProduto_UC(this);
            window.Title = "Adicionar Disciplina Estoque";
            window.Content = listaUC;
            window.ShowDialog();
        }
    }
}
