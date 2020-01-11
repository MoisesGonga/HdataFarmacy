using BLL;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using HDATA_PHARMACY.Extras;

namespace HDATA_PHARMACY.Views.Cliente
{
    /// <summary>
    /// Interaction logic for ListaCliente_UC.xaml
    /// </summary>
    public partial class ListaCliente_UC : UserControl
    {
        cliente ClienteSelecionado;
        ClienteBLL clienteBLL;
       // MetroWindow metroWindow;
        List<cliente> Lista_Cliente;
        private SearchContent_Window window;

        public ListaCliente_UC()
        {
            InitializeComponent();
        }

        /*
        public ListaCliente_UC(MetroWindow metroWindow)
        {
            InitializeComponent();
            clienteBLL = new ClienteBLL();
            CarregarDadosCliente();
            this.metroWindow = metroWindow;
            this.btn_seleccionar.Visibility = Visibility.Visible;
            //btn_imprimir.Visibility = Visibility.Collapsed;
            btn_eliminar.Visibility = Visibility.Collapsed;
            btn_editar.Visibility = btn_novo.Visibility = Visibility.Collapsed;
        }
        */

        public ListaCliente_UC(SearchContent_Window window)
        {
            this.window = window;
            InitializeComponent();
            clienteBLL = new ClienteBLL();
            CarregarDadosCliente();
            this.btn_seleccionar.Visibility = Visibility.Visible;
            btn_eliminar.Visibility = Visibility.Collapsed;
            btn_editar.Visibility = btn_novo.Visibility = Visibility.Collapsed;

        }

        private void TableView_KeyDown(object sender, KeyEventArgs e)
        {
            if (datagrid_cliente.SelectedItems.Count > 0 && e.Key == Key.F4)
            {
                SeleccionarCliente();
                this.window.Close();
            }
        }

        public cliente SeleccionarCliente()
        {
            if (datagrid_cliente.SelectedItem != null)
            {
                ClienteSelecionado = this.datagrid_cliente.SelectedItem as cliente;
                return ClienteSelecionado;
            }
            return null;
        }

        public void CarregarDadosCliente()
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
            datagrid_cliente.ItemsSource = null;
            datagrid_cliente.ItemsSource = Lista_Cliente;
            border_async_load_produto.Visibility = Visibility.Collapsed;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Lista_Cliente = clienteBLL.Listar();
        }

        private void btn_actualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregarDadosCliente();
        }

        private void btn_seleccionar_Click(object sender, RoutedEventArgs e)
        {
            SeleccionarCliente();
            this.window.Close();
        }
    }
}
