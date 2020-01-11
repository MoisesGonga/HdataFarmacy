using BLL;
using HDATA_PHARMACY.Security;
using HDATA_PHARMACY.Views.Facturacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HDATA_PHARMACY.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private  void btn_entrar_Click(object sender, RoutedEventArgs e)
        {
             Login_Utilizador();
            //POS_Window w = new POS_Window();
            //w.Show();
        }

        private void btn_sair_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow h = new HomeWindow();
            h.Show();
        }

        private bool Validar()
        {
            if (txt_username.Text.Trim() == string.Empty || txt_password.Password == string.Empty)
            {
                return false;
            }
            return true;
        }

        private async void Login_Utilizador()
        {
            try
            {
                var current = this.Background;
                if (Validar())
                {
                    lbl_processamento.Visibility = Visibility.Visible;
                    lbl_processamento.Text = "A Autenticar...";
                    lbl_processamento.Foreground = Brushes.Green;
                    utilizador Utilizador = null;
                    UtilizadorBLL utilizadorBll = new UtilizadorBLL();
                    //await Task.Delay(100);
                    Utilizador = await utilizadorBll.Login(txt_username.Text, txt_password.Password);
                    if (Utilizador == null)
                    {
                        var blur = new BlurEffect();
                        blur.Radius = 8;

                        this.Background = new SolidColorBrush(Color.FromRgb(240, 240, 240));
                        this.Effect = blur;
                       // MessageBox.Show("Nome do Utilizador ou Palavra-Passe incorrecta.", Properties.Settings.Default.MessageTitleMessageBox, MessageBoxButton.OK, MessageBoxImage.Error);
                        lbl_processamento.Text = "Nome do Utilizador ou Palavra-Passe incorrecta.";
                        this.Background = current;
                        this.Effect = null;
                        lbl_processamento.Text = "Credenciais inválidas.";
                        lbl_processamento.Foreground = Brushes.Red;
                        await Task.Delay(1500);
                        lbl_processamento.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        if (Utilizador.status.Equals(1))
                        {
                            Splash splash = new Splash();
                            if (Utilizador.tipo_utilizador.descricao.ToLower().Equals(UserType.Simples.ToString().ToLower()))
                            {
                                AppCommon.LogedUserType = UserType.Simples;
                            }
                            if (Utilizador.tipo_utilizador.descricao.ToLower().Equals(UserType.Admin.ToString().ToLower()))
                            {
                                AppCommon.LogedUserType = UserType.Admin;
                            }
                            if (Utilizador.tipo_utilizador.descricao.ToLower().Equals(UserType.SuperAdmin.ToString().ToLower()))
                            {
                                AppCommon.LogedUserType = UserType.SuperAdmin;
                            }
                            AppCommon.idUsuario = Utilizador.id_utilizador;

                            lbl_processamento.Visibility = Visibility.Visible;

                            lbl_processamento.Text = "Autenticação efectuada com sucesso.";
                            lbl_processamento.Foreground = Brushes.Green;
                            Thread.Sleep(1500);
                            this.Visibility = Visibility.Hidden;
                            splash.ShowDialog();
                            POS_Window w = new POS_Window();
                            this.Visibility = Visibility.Collapsed;
                            w.Show();
                        }
                        else
                        {
                            var blur = new BlurEffect();
                            blur.Radius = 8;
                            this.Background = new SolidColorBrush(Color.FromRgb(240, 240, 240));
                            this.Effect = blur;
                            lbl_processamento.Text = "Não está habilitado para entrar no sistema.";
                            //MessageBox.Show("Não está habilitado para entrar no sistema.", "Entrar", MessageBoxButton.OK, MessageBoxImage.Warning);
                            this.Background = current;
                            this.Effect = null;
                            lbl_processamento.Text = "Conta desactivada.";
                            lbl_processamento.Foreground = Brushes.Red;
                            await Task.Delay(2000);
                            lbl_processamento.Visibility = Visibility.Collapsed;
                        }
                        this.Background = current;
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_processamento.Visibility = Visibility.Visible;
                MessageBox.Show("Ocorreu uma excepção: " + ex.Message);
                lbl_processamento.Text = "Falha na conexão com o banco de dados!";
                lbl_processamento.Foreground = Brushes.Red;
                await Task.Delay(1500);
                lbl_processamento.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login_Utilizador();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
