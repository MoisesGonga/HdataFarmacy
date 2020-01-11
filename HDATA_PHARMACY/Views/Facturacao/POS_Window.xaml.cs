using BLL;
using HDATA_PHARMACY.Extras;
using HDATA_PHARMACY.Security;
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
using System.Windows.Threading;

namespace HDATA_PHARMACY.Views.Facturacao
{
    /// <summary>
    /// Lógica interna para POS_Window.xaml
    /// </summary>
    public partial class POS_Window : Window
    {

        GridLength gridlength;
        public bool stateMenu { get; set; }
        DispatcherTimer dispacherTimer = new DispatcherTimer();
        public bool IsCaixaTurnOn { get; set; }
        public caixa Caixa { get; set; }
        CaixaBLL CaixaBll;
        public POS_Window()
        {
            InitializeComponent();
            CaixaBll = new CaixaBLL();
            Venda_UC venda_Uc = new Venda_UC();
            GridVenda.Children.Add(venda_Uc);
            //BARRA LATERAL RESPONSIVA
            dispacherTimer = new DispatcherTimer();
            stateMenu = true;
            dispacherTimer.Tick += new EventHandler(timer_tick);
            dispacherTimer.Interval = new TimeSpan(0, 0, 0, 0, 0);
            //FIM - BARRA LATERAL RESPONSIVA
            UtilizadorBLL utilizadorBLL = new UtilizadorBLL();
            var Utilizador = utilizadorBLL.ObterPeloId(AppCommon.idUsuario);
            if (HelperView.IsNotNull(Utilizador))
            {
                if (HelperView.IsNotNull(Utilizador.nome))
                    lbl_user.Content = Utilizador.nome;

                ObterCaixaActual();
            }
        }

        private caixa ObterCaixaActual() {
            var Caixa = CaixaBll.ObterCaixaAberto(AppCommon.idUsuario);
            if (HelperView.IsNotNull(Caixa))
            {
                //  Caixa = CaixaBll.ObterCaixaAberto(AppCommon.idUsuario);
                CheckCaixaAberto(Caixa);
            }
            else
            {
                Caixa = null;
                BloquearInterface();
            }

            return Caixa;
        }
        /// <summary>
        /// Este método válida se o caixa actual está em aberto!
        /// </summary>
        /// <param name="Caixa"></param>
        /// <returns>
        /// 
        /// </returns>
        private bool CheckCaixaAberto(caixa Caixa)
        {
            if (HelperView.IsNotNull(Caixa))
            {
                if (Caixa.estado_caixa.ToLower().Equals("aberto")) {
                    this.Caixa = Caixa;
                    HabilitarInterface();
                    return true;
                }
                BloquearInterface();
                return false;

            }
            BloquearInterface();
            return false;
        }

        private void HabilitarInterface()
        {
            Trv_AbrirCaixa.IsEnabled = false;
            GridVenda.Visibility = Visibility.Visible;
            Trv_FecharCaixa.IsEnabled = true;
            BorderLock.Visibility = Visibility.Collapsed;
        }

        private void BloquearInterface()
        {
            Trv_AbrirCaixa.IsEnabled = true;
            Trv_FecharCaixa.IsEnabled = false;
            GridVenda.Visibility = Visibility.Collapsed;
            BorderLock.Visibility = Visibility.Visible;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            if (!(grid_colum0.Width.Value <= 260))
            {
                dispacherTimer.Stop();
                stateMenu = stateMenu == true ? false : true;
               // AlterIconeMenu();
            }
            else
            {
                if (stateMenu)
                {
                    gridlength = new GridLength(grid_colum0.Width.Value - 13);
                }
                else
                {
                    gridlength = new GridLength(grid_colum0.Width.Value + 13);
                }
                if (grid_colum0.Width.Value == 0 && stateMenu)
                {
                    dispacherTimer.Stop();
                    stateMenu = stateMenu == true ? false : true;
                   // AlterIconeMenu();
                }
                else
                {
                    grid_colum0.Width = gridlength;
                }
                if (grid_colum0.Width.Value == 260 && !stateMenu)
                {
                    dispacherTimer.Stop();
                    stateMenu = stateMenu == true ? false : true;
                   // AlterIconeMenu();
                }
            }

        }

        private void btn_show_hide_menu_Click(object sender, RoutedEventArgs e)
        {
            dispacherTimer.Start();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                dispacherTimer.Start();
            }
        }

        private void Trv_AbrirCaixa_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Abertura_Caixa abertura_Caixa = new Abertura_Caixa();
            abertura_Caixa.ShowDialog();
            ObterCaixaActual();

        }

        private void Trv_FecharCaixa_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (HelperView.IsNotNull(Caixa))
                {
                    Fecho_CaixaWindow fecho_Caixa = new Fecho_CaixaWindow(Caixa.id_caixa);
                    if (fecho_Caixa.IsCaixaFechado)
                    {
                        Caixa = null;
                        ObterCaixaActual();
                        BloquearInterface();
                    }
                    else
                    {
                        fecho_Caixa.ShowDialog();
                        if (fecho_Caixa.IsCaixaFechado)
                        {
                            Caixa = null;
                            ObterCaixaActual();
                            BloquearInterface();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Atenção o caixa está fechado, efectue a abertura!", Properties.Settings.Default.MessageTitleMessageBox, MessageBoxButton.OK, MessageBoxImage.Warning);
                    BloquearInterface();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao abrir a tela para o fechamento do caixa.", Properties.Settings.Default.MessageTitleMessageBox, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Trv_EntradaCaixa_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Entrada_Saida_Caixa caixa = new Entrada_Saida_Caixa(TipoOperacaoCaixa.ENTRADA);
                if (caixa.IsCaixaTurnOn)
                {
                    caixa.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Atenção o caixa está fechado, efectue a abertura!", Properties.Settings.Default.MessageTitleMessageBox, MessageBoxButton.OK, MessageBoxImage.Warning);
                    BloquearInterface();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao abrir a tela para dar entrada no caixa.", Properties.Settings.Default.MessageTitleMessageBox, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Trv_SaidaCaixa_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Entrada_Saida_Caixa caixa = new Entrada_Saida_Caixa(TipoOperacaoCaixa.SAIDA);
                if (caixa.IsCaixaTurnOn)
                {
                    caixa.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Atenção o caixa está fechado, efectue a abertura!", Properties.Settings.Default.MessageTitleMessageBox, MessageBoxButton.OK, MessageBoxImage.Warning);
                    BloquearInterface();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao abrir a tela para dar saida no caixa.", Properties.Settings.Default.MessageTitleMessageBox, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        private void Trv_ResumoCaixa_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
