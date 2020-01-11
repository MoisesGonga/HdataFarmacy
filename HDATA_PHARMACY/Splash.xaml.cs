using HDATA_PHARMACY.Views;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HDATA_PHARMACY
{
    /// <summary>
    /// Lógica interna para Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        DispatcherTimer timer;
        public Splash()
        {
            this.BringIntoView();
            InitializeComponent();

            txt_carregando.Text = "Carregando componentes  do sistema...";
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            timer.Tick += new EventHandler((s, e) => {
                if (mainProgressBar.Value <= 100)
                {
                    if (mainProgressBar.Value >= 70 && mainProgressBar.Value < 90)
                    {
                        timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
                        txt_carregando.Text = "Finalizando o carregamento do sistema...";

                    }
                    else if (mainProgressBar.Value >= 90 && mainProgressBar.Value <= 100)
                    {
                        txt_carregando.Text = "Sistema carregado com sucesso...";
                        timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
                    }
                    else if (mainProgressBar.Value >= 0 && mainProgressBar.Value <= 10)
                        txt_carregando.Text = "Seja Bem-vindo ao HDATA PHARMACY";
                    else if (mainProgressBar.Value > 10 && mainProgressBar.Value < 30)
                    {
                        timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
                        txt_carregando.Text = "O sistema está carregando os componentes";
                    }
                    else if (mainProgressBar.Value >= 30 && mainProgressBar.Value <= 70)
                    {
                        timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
                        txt_carregando.Text = "Verificando os componentes...";
                    }
                    mainProgressBar.Value += 1;
                }
                if (mainProgressBar.Value >= 100)
                {
                    this.timer.IsEnabled = false;
                    timer.Stop();
                    this.Close();
                }
            });
            timer.Start();
            CarregarControle();

        }

        public Splash(LoginWindow login)
        {
            this.BringIntoView();
            InitializeComponent();

            txt_carregando.Text = "Carregando componentes  do sistema...";
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            timer.Tick += new EventHandler((s, e) => {
                if (mainProgressBar.Value <= 100)
                {
                    if (mainProgressBar.Value >= 70 && mainProgressBar.Value < 90)
                    {
                        timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
                        txt_carregando.Text = "Finalizando o carregamento do sistema...";

                    }
                    else if (mainProgressBar.Value >= 90 && mainProgressBar.Value <= 100)
                    {
                        txt_carregando.Text = "Sistema carregado com sucesso...";
                        timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
                    }
                    else if (mainProgressBar.Value >= 0 && mainProgressBar.Value <= 10)
                        txt_carregando.Text = "Seja Bem-vindo ao HDATA PHARMACY";
                    else if (mainProgressBar.Value > 10 && mainProgressBar.Value < 30)
                    {
                        timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
                        txt_carregando.Text = "O sistema está carregando os componentes";
                    }
                    else if (mainProgressBar.Value >= 30 && mainProgressBar.Value <= 70)
                    {
                        timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
                        txt_carregando.Text = "Verificando os componentes...";
                    }

                    //  if (mainProgressBar.Value % 4 == 0)
                    //lbl_carregando.Content = "";
                    // else
                    //lbl_carregando.Content += ".";
                    mainProgressBar.Value += 1;
                    //this.lbl_percentagem.Content = mainProgressBar.Value.ToString() + "%";
                }
                if (mainProgressBar.Value >= 100)
                {
                    this.timer.IsEnabled = false;
                    timer.Stop();

                }
            });
            timer.Start();
            CarregarControle();
            //login.Close();
            this.Close();

        }

        private async void CarregarControle()
        {
            await this.Dispatcher.InvokeAsync(() => {
                ListaProduto_UC listaProduto_UC = new ListaProduto_UC();
                listaProduto_UC.Width = 1;
                listaProduto_UC.Height = 1;
                stack_loading.Children.Add(listaProduto_UC);
            });
        }

    }
}
