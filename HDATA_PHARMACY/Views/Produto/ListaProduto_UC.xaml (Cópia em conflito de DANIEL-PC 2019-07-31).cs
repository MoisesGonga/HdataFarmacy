using BLL;
using HDATA_PHARMACY.Extras;
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
        ProdutoBLL produtoBLL;
        // MetroWindow metroWindow;
        List<produto> Lista_Produto;
        List<produto> Lista_ProdutosSelecionados;
        private SearchContent_Window window;

        public ListaProduto_UC()
        {
            InitializeComponent();
            tableViewProduto.ShowCheckBoxSelectorColumn = false;
            CarregarDadosProduto();
        }

        public ListaProduto_UC(SearchContent_Window window)
        {
            this.window = window;
            InitializeComponent();
            produtoBLL = new ProdutoBLL();
            tableViewProduto.ShowCheckBoxSelectorColumn = true;
            CarregarDadosProduto();
            this.btn_seleccionar.Visibility = Visibility.Visible;
            btn_eliminar.Visibility = Visibility.Collapsed;
            btn_editar.Visibility = btn_novo.Visibility = Visibility.Collapsed;

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
                ProdutoSelecionado = this.datagrid_produto.SelectedItem as produto;
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
            datagrid_produto.ItemsSource = Lista_Produto;
            border_async_load_produto.Visibility = Visibility.Collapsed;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Lista_Produto = produtoBLL.Listar();
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
    }
}
