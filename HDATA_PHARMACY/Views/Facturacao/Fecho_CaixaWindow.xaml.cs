using BLL;
using HDATA_PHARMACY.Extras;
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
using System.Windows.Shapes;

namespace HDATA_PHARMACY.Views.Facturacao
{
    /// <summary>
    /// Lógica interna para Fecho_CaixaWindow.xaml
    /// </summary>
    public partial class Fecho_CaixaWindow : Window
    {
        int idCaixa;
        CaixaBLL caixaBLL;
        public bool IsCaixaFechado { get; set; }

        public Fecho_CaixaWindow()
        {
            InitializeComponent();
        }

        public Fecho_CaixaWindow(int idCaixa)
        {
            InitializeComponent();
            caixaBLL = new CaixaBLL();
            CarregarInfo(idCaixa);
        }

        private async void CarregarInfo(int idCaixa)
        {
            var Caixa = caixaBLL.ObterPeloId(idCaixa);
            if (HelperView.IsNotNull(Caixa))
            {
                if (Caixa.estado_caixa.ToLower().Equals("aberto"))
                {
                    this.idCaixa = idCaixa;
                    IsCaixaFechado = false;
                    VendaBLL vendaBll = new VendaBLL();
                    var ListVendaCaixa = await vendaBll.ListarVendaCaixaAsync(idCaixa);
                    lbl_QtdVendaValida.Content = ListVendaCaixa.Where(t => t.status == 1).Count();
                    lbl_QtdVendaAnulada.Content = ListVendaCaixa.Where(t => t.status == 0).Count();
                    lbl_QtdTotalVenda.Content = ListVendaCaixa.Count;

                    double SaldoInicial = Caixa.valor_inicial;
                    double ValorTotalVenda = ListVendaCaixa.Sum(t => t.total_venda);
                    double DinheiroAdicionado = Caixa.movimento_caixa.Where(t => t.id_tipo_movimento == 1).Sum(t => t.valor_movimento);
                    double DinheiroRetirado = Caixa.movimento_caixa.Where(t => t.id_tipo_movimento == 2).Sum(t => t.valor_movimento);
                    double SaldoFinal = (ValorTotalVenda + DinheiroAdicionado + SaldoInicial) - (DinheiroRetirado);
                    lbl_ValorSaldoInicial.Content = HelperView.FormatDouble_Money(SaldoInicial);
                    lbl_ValorTotalVenda.Content = HelperView.FormatDouble_Money(ValorTotalVenda);
                    lbl_DinheiroAdicionado.Content = HelperView.FormatDouble_Money(DinheiroAdicionado);
                    lbl_DinheiroRetirado.Content = HelperView.FormatDouble_Money(DinheiroRetirado);
                    lbl_SaldoFinal.Content = HelperView.FormatDouble_Money(SaldoFinal);
                }
            }
            else
            {
                MessageBox.Show("Atenção o caixa já foi fechado!", Properties.Settings.Default.MessageTitleMessageBox, MessageBoxButton.OK, MessageBoxImage.Warning);
                this.Close();
            }
            
        }

        private void btn_salvar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Tem certeza que pretende fechar o caixa?", Properties.Settings.Default.MessageTitleMessageBox, MessageBoxButton.YesNo, MessageBoxImage.Question).Equals(MessageBoxResult.Yes))
            {
                var Caixa = caixaBLL.FecharCaixa(idCaixa);
                if (HelperView.IsNotNull(Caixa))
                {
                    MessageBox.Show("O Caixa foi fechado com sucesso", Properties.Settings.Default.MessageTitleMessageBox, MessageBoxButton.OK, MessageBoxImage.Information);
                    IsCaixaFechado = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao fechar o caixa, caso o erro persista, contacte o Administrador do sistema!", Properties.Settings.Default.MessageTitleMessageBox, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            
        }

        private void btn_imprimir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
