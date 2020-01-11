using BLL;
using HDATA_PHARMACY.Extras;
using HDATA_PHARMACY.Views.Estoque;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interação lógica para ListaProduto_UC.xam
    /// </summary>
    public partial class ListaProduto_UC : UserControl
    {
        produto ProdutoSelecionado;
        lote LoteSeleccionado;
        ProdutoBLL produtoBLL;
        LoteBLL loteBLL;
        EstoqueProdutoBLL EstoqueProdutoBLL;
        // MetroWindow metroWindow;
        List<produto> Lista_Produto;
        List<lote> Lista_Lote; 
        List<estoque_produto> Lista_Estoque; 
         LoteAdicionar_UC LoteAdicionar_UC;
        EstoqueAdicionar_UC EstoqueAdicionar_UC;
        MovimentoEstoqueAdicionar_UC MovimentoEstoqueAdicionar_UC;
        List<produto> Lista_ProdutosSelecionados;
        private SearchContent_Window window;

        public ListaProduto_UC()
        {
            InitializeComponent();
            tableViewProduto.ShowCheckBoxSelectorColumn = false;
            CarregarDadosProduto();
            this.LoteAdicionar_UC = null;
        }

        public ListaProduto_UC(SearchContent_Window window)
        {
            this.window = window;
            InitializeComponent();
            produtoBLL = new ProdutoBLL();
            loteBLL = new LoteBLL();
            tableViewProduto.ShowCheckBoxSelectorColumn = true;
            CarregarDadosProduto();
            this.btn_seleccionar.Visibility = Visibility.Visible;
            btn_eliminar.Visibility = Visibility.Collapsed;
            btn_editar.Visibility = btn_novo.Visibility = Visibility.Collapsed;

            this.LoteAdicionar_UC = null;

        }
        
             public ListaProduto_UC(SearchContent_Window window, EstoqueAdicionar_UC EstoqueAdicionar_UC)
        {
            this.window = window;
            InitializeComponent();
            produtoBLL = new ProdutoBLL();
            loteBLL = new LoteBLL();
            tableViewProduto.ShowCheckBoxSelectorColumn = true;
            CarregarDadosProduto();
            this.btn_seleccionar.Visibility = Visibility.Visible;
            btn_eliminar.Visibility = Visibility.Collapsed;
            btn_editar.Visibility = btn_novo.Visibility = Visibility.Collapsed;
            this.EstoqueAdicionar_UC = EstoqueAdicionar_UC;

        }
        public ListaProduto_UC(SearchContent_Window window, LoteAdicionar_UC LoteAdicionar_UC)
        {
            this.window = window;
            InitializeComponent();
            produtoBLL = new ProdutoBLL();
            loteBLL = new LoteBLL();
            tableViewProduto.ShowCheckBoxSelectorColumn = true;
            CarregarDadosProduto();
            this.btn_seleccionar.Visibility = Visibility.Visible;
            btn_eliminar.Visibility = Visibility.Collapsed;
            btn_editar.Visibility = btn_novo.Visibility = Visibility.Collapsed;
            this.LoteAdicionar_UC = LoteAdicionar_UC;

        }

        public ListaProduto_UC(SearchContent_Window window, MovimentoEstoqueAdicionar_UC MovimentoEstoqueAdicionar_UC)
        {
            this.window = window;
            InitializeComponent();
            produtoBLL = new ProdutoBLL();
            loteBLL = new LoteBLL();
            this.EstoqueProdutoBLL = new EstoqueProdutoBLL();
            tableViewProduto.ShowCheckBoxSelectorColumn = true;
            CarregarDadosProduto();
            this.btn_seleccionar.Visibility = Visibility.Visible;
            btn_eliminar.Visibility = Visibility.Collapsed;
            btn_editar.Visibility = btn_novo.Visibility = Visibility.Collapsed;
            this.MovimentoEstoqueAdicionar_UC = MovimentoEstoqueAdicionar_UC;

        }


        private void TableView_KeyDown(object sender, KeyEventArgs e)
        {
            if (datagrid_produto.SelectedItems.Count > 0 && e.Key == Key.F4)
            {
                SeleccionarProduto();
                this.window.Close();
            }
        }

        public produto SeleccionarProduto()
        {
            if (datagrid_produto.SelectedItem != null)
            {
               //this.datagrid_produto.SelectedItem as produto;
                if (this.LoteAdicionar_UC!=null)
                {
                    ProdutoSelecionado = this.datagrid_produto.SelectedItem as produto;
                    this.LoteAdicionar_UC.SeleccionarProduto(ProdutoSelecionado);
                }
                else if (this.EstoqueAdicionar_UC!=null)
                {
                    LoteSeleccionado = this.datagrid_produto.SelectedItem as lote;
                    ProdutoSelecionado = LoteSeleccionado.produto;
                    this.EstoqueAdicionar_UC.SeleccionarLote(LoteSeleccionado);
                }
                else if (this.MovimentoEstoqueAdicionar_UC != null)
                {
                    LoteSeleccionado = this.datagrid_produto.SelectedItem as lote;
                    ProdutoSelecionado = LoteSeleccionado.produto;
                    this.MovimentoEstoqueAdicionar_UC.SeleccionarLote(LoteSeleccionado);
                }

                return ProdutoSelecionado;
            }
            return null;
        }

        public List<produto> SeleccionarProdutos()
        {
            List<produto> listProduto = new List<produto>();
            if (datagrid_produto.SelectedItem != null)
            {
                listProduto = this.datagrid_produto.SelectedItems as List<produto>;
                return listProduto;
            }
            return null;
        }

        public void CarregarDadosProduto()
        {
            border_async_load_produto.Visibility = Visibility.Visible;
            BackgroundWorker worker = new BackgroundWorker();
            //worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            datagrid_produto.ItemsSource = null;
            datagrid_produto.ItemsSource = Lista_Lote;
            if (LoteAdicionar_UC != null )
            {
                datagrid_produto.ItemsSource = Lista_Produto;

                datagrid_produto.Columns[1].FieldName = "nome";
               

            }
            else if (MovimentoEstoqueAdicionar_UC != null) {
                datagrid_produto.ItemsSource = Lista_Estoque;
              //MessageBox.Show(Lista_Estoque.Count.ToString());
                 datagrid_produto.Columns[1].FieldName = "lote.produto.nome";
                datagrid_produto.Columns[2].FieldName = "local_estoque.descricao";
                datagrid_produto.Columns[2].Header = "local_estoque.descricao";

                //toque_produto a = new estoque_produto().local_estoque.descricao
            }

            //Lista_Produto;//
            border_async_load_produto.Visibility = Visibility.Collapsed;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Lista_Produto = produtoBLL.Listar();
            Lista_Lote = this.loteBLL.Listar();

            if (HelperView.IsNotNull(LoteAdicionar_UC))            
            Lista_Estoque = this.EstoqueProdutoBLL.Listar();
        }

        private void btn_actualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregarDadosProduto();
        }

        private void btn_seleccionar_Click(object sender, RoutedEventArgs e)
        {
            SeleccionarProduto();
            this.window.Close();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
