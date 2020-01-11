using BLL;
using HDATA_PHARMACY.Extras;
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

namespace HDATA_PHARMACY.Views.Estoque
{
    /// <summary>
    /// Interaction logic for EstoqueAdicionar_UC.xaml
    /// </summary>
    public partial class EstoqueAdicionar_UC : UserControl
    {
        lote LoteSeleccionado;
        public EstoqueAdicionar_UC()
        {
            InitializeComponent();
            CarregarDados();
            TxtInfoLote.IsEnabled = false;
           
        }
        private void CarregarDados()
        {
            CarregarLocalEstoque();
        }
        public void CarregarLocalEstoque()
        {
            LocalEstoqueBLL condicaoPagamentoBll = new LocalEstoqueBLL();
            Cmb_LocalEstoque.DisplayMemberPath = "descricao";
            Cmb_LocalEstoque.ItemsSource = null;
            Cmb_LocalEstoque.ItemsSource = condicaoPagamentoBll.Listar();
            
        }
        private void btn_Produto_Click(object sender, RoutedEventArgs e)
        {
            /*SearchContent_Window window = new SearchContent_Window();


            ProdutoAdicionar_UC listaUC = new ProdutoAdicionar_UC(this);
            window.Title = "Adicionar de Produto";
            window.Content = listaUC;
            window.ShowDialog();
            */

            SearchContent_Window window = new SearchContent_Window();
            ListaProduto_UC listaUC = new ListaProduto_UC(window, this);
            window.Title = "Consulta de Produtos";
            window.Content = listaUC;
            window.ShowDialog();


        }

        public void SeleccionarLote(lote lote)
        {
            this.LoteSeleccionado = lote;
            TxtInfoLote.Text = LoteSeleccionado.produto.nome +"-"+ LoteSeleccionado.info_lote;
            

           // MessageBox.Show(LoteSeleccionado.info_lote);
          //  Cmb_Produto.IsEnabled = false;

        }
        private void btn_Fornecedor_Click(object sender, RoutedEventArgs e)
        {
            SearchContent_Window window = new SearchContent_Window();
            
            LocalEstoqueAdicionar_UC listaUC = new LocalEstoqueAdicionar_UC(this);
            window.Title = "Adicionar de Fornecedor";
            window.Content = listaUC;
            window.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Salvar();
                SalvarMovimento();
                MessageBox.Show("Salvo");
            }
            catch (Exception)
            {

                MessageBox.Show("erro");
            }
           

        }
        private void SalvarMovimento()
        {
            movimento_estoque novo = new movimento_estoque();
            novo.data = DateTime.Now;
            novo.data_compra = data_compra.SelectedDate;
            novo.ajuste = 0;
            novo.descricao = "Primeira Inserção";
             
            novo.id_local_estoque = (Cmb_LocalEstoque.SelectedItem as local_estoque).id_local_estoque;
            novo.id_lote= LoteSeleccionado.id_lote;
            novo.id_produto = LoteSeleccionado.id_produto;
            novo.id_tipo_movimento = 1;
            novo.id_utilizador = 1;
            novo.preco_compra = float.Parse(LoteSeleccionado.preco_compra.ToString()); 
            novo.qtd = Convert.ToInt32(TxtQtdActal.Text);


            MovimentoEstoqueBLL MovimentoEstoqueBLL = new MovimentoEstoqueBLL();
            MovimentoEstoqueBLL.Cadastrar(novo);

        }
        private void Salvar()
        {
            estoque_produto novo = new estoque_produto();

            novo.lote = LoteSeleccionado as lote;
            novo.id_lote = LoteSeleccionado.id_lote;           
            novo.local_estoque = Cmb_LocalEstoque.SelectedItem as local_estoque;
            novo.id_local_estoque = novo.local_estoque.id_local_estoque;
            novo.id_produto = LoteSeleccionado.id_produto;
            novo.data_criacao = DateTime.Now;
            novo.qtd_encomenda = Convert.ToInt32(TxtQtdMaxima.Text);
            //Devemos  colocar o id do usuario real 

            novo.id_user = 1;
           novo.qtd_minima = Convert.ToInt32(TxtQtdMinima.Text);
            novo.qtd_existente = Convert.ToInt32(TxtQtdActal.Text);
            novo.preco_venda = (float)( LoteSeleccionado.preco_venda ) ;

            EstoqueProdutoBLL EstoqueProdutoBLL = new EstoqueProdutoBLL();
            EstoqueProdutoBLL.Cadastrar(novo);

        }
    }
}
