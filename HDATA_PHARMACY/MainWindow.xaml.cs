using BLL;
using SourceChord.FluentWPF;
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

namespace HDATA_PHARMACY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AcrylicWindow
    {
        public MainWindow()
        {
            CarregarDatagrid();
            InitializeComponent();

            

        }

        private async void CarregarDatagrid()
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            await Task.Run(() =>
            {
                MessageBox.Show("Mensagem 1");
           /* for (int i = 13002; i < 20000; i++)
            {
                cliente C1 = new cliente();
                C1.idade = i;
                C1.nome = "User "+i;
                clienteBLL.CadastrarCliente(C1);
            }*/
           });
            MessageBox.Show("Mensagem 2");
            ClienteDatagrid.ItemsSource = await clienteBLL.ListarAsync();
           /* MessageBox.Show($"Total clientes: {clienteBLL.ListarTotal()}");
            MessageBox.Show($"Clientes Maior 1000: {clienteBLL.ListarClientMaior1000()}");
            MessageBox.Show($"Clientes Menor 1000: {clienteBLL.ListarClientMenor1000()}");*/
        }

        private void CarregarDatagri1d()
        {
         /*ClienteBLL clienteBLL = new ClienteBLL();
            cliente C1 = new cliente();
            C1.idade = 60;
            C1.nome = "Amaro";
            clienteBLL.Cadastrar(C1);*/
         //ClienteDatagrid.ItemsSource =  clienteBLL.ListarCliente();
        }


    }
}
