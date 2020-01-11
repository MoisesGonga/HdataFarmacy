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
    /// Interaction logic for MovimentoEstoqueAdicionar_UC.xaml
    /// </summary>
    public partial class MovimentoEstoqueAdicionar_UC : UserControl
    {
        lote LoteSeleccionado;
        public MovimentoEstoqueAdicionar_UC()
        {
            InitializeComponent();
            BttSalvar.IsEnabled = false;
            CarregarLocalEstoque();
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
            TxtInfoLote.Text = LoteSeleccionado.produto.nome + "-" + LoteSeleccionado.info_lote;


            // MessageBox.Show(LoteSeleccionado.info_lote);
            //  Cmb_Produto.IsEnabled = false;

        }
        private void checkBox_Ajuste_Checked(object sender, RoutedEventArgs e)
        {
            
        }
        private void btn_salvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                MessageBox.Show("salvo");

            }
            catch (Exception)
            {

                MessageBox.Show("erro ao salvar");
            }



        }
        public void CarregarLocalEstoque()
        {
            LocalEstoqueBLL condicaoPagamentoBll = new LocalEstoqueBLL();
            Cmb_LocalEstoque.DisplayMemberPath = "descricao";
            Cmb_LocalEstoque.ItemsSource = null;
            Cmb_LocalEstoque.ItemsSource = condicaoPagamentoBll.Listar();

        }
        public void CarregarTipoMovimento()
        {
           /* TipoMovimentoBLL condicaoPagamentoBll = new TipoMovimentoBLL();
            Cmb_Tipo_Movimento.DisplayMemberPath = "descricao";
            Cmb_Tipo_Movimento.ItemsSource = null;
            Cmb_Tipo_Movimento.ItemsSource = condicaoPagamentoBll.Listar();
            */

        }
        private void btn_Local_Click(object sender, RoutedEventArgs e)
        {
            SearchContent_Window window = new SearchContent_Window();

            LocalEstoqueAdicionar_UC listaUC = new LocalEstoqueAdicionar_UC(this);
            window.Title = "Adicionar de Local Estoque";
            window.Content = listaUC;
            window.ShowDialog();
        }

        private void Cmb_Tipo_Movimento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
        private void SalvarAjuste()
        {
            movimento_estoque mov = new movimento_estoque();
            mov.ajuste = 1;
            mov.data = DateTime.Now;
            mov.descricao = TxtDescricao.Text;
            mov.id_local_estoque = (Cmb_LocalEstoque.SelectedItem as local_estoque).id_local_estoque;
            mov.id_lote = LoteSeleccionado.id_lote;
            mov.id_produto = LoteSeleccionado.id_produto;
            mov.id_tipo_movimento = 1;
            mov.qtd = Convert.ToInt32(TxtQtdMovimentar);

            MovimentoEstoqueBLL movBLL = new MovimentoEstoqueBLL();
            movBLL.Cadastrar(mov);
                


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {  if ((bool)radioButtonAjuste.IsChecked)
            {
                SalvarAjuste();
                    MessageBox.Show("Movimento de Ajuste Salvo com Sucesso");

                }
            else if ((bool)radioButtonAdicao.IsChecked)
            {

            }
            else if ((bool)radioButtonTransferencia.IsChecked)
            {

            }

            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao Salvar Movimento");
            }
          
            

        }

        private void btn_Fornecedor_Click(object sender, RoutedEventArgs e)
        {
            SearchContent_Window window = new SearchContent_Window();

            LocalEstoqueAdicionar_UC listaUC = new LocalEstoqueAdicionar_UC(this);
            window.Title = "Adicionar de Local Estoque";
            window.Content = listaUC;
            window.ShowDialog();
        }

        private void checkBox_Cliente_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void radioButtonAjuste_Checked(object sender, RoutedEventArgs e)
        {
            TxtPrecoCompra.IsEnabled = false;
            data_compra.IsEnabled = false;
            Cmb_LocalEstoqueDestino.IsEnabled = false;
            BttSalvar.IsEnabled = true;
        }

        private void radioButtonTransferencia_Checked(object sender, RoutedEventArgs e)
        {
            TxtPrecoCompra.IsEnabled = false;

            data_compra.IsEnabled = false;
            Cmb_LocalEstoqueDestino.IsEnabled = true;

            BttSalvar.IsEnabled = true;
        }

        private void radioButtonAdicao_Checked(object sender, RoutedEventArgs e)
        {
            Cmb_LocalEstoqueDestino.IsEnabled = false;

            TxtPrecoCompra.IsEnabled = true;
            data_compra.IsEnabled = true;

            BttSalvar.IsEnabled = true;

        }
    }
}
