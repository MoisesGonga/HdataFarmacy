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

namespace HDATA_PHARMACY.Views.Facturacao
{
    /// <summary>
    /// Lógica interna para Abertura_Caixa.xaml
    /// </summary>
    public partial class Abertura_Caixa : Window
    {
        public Abertura_Caixa()
        {
            InitializeComponent();
        }

        private void btn_salvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Tem certeza que pretende abrir o caixa com {HelperView.FormatDouble_Money(double.Parse(txt_valor_inicial.Text))}?",Properties.Settings.Default.MessageTitleMessageBox,MessageBoxButton.YesNo,MessageBoxImage.Question).Equals(MessageBoxResult.Yes))
                {
                    caixa Caixa = new caixa()
                    {
                        data_abertura = DateTime.Now,
                        estado_caixa = "Aberto",
                        id_utilizador = AppCommon.idUsuario,
                        valor_inicial = double.Parse(txt_valor_inicial.Text),
                        data_actualizacao = DateTime.Now,
                        saldo = double.Parse(txt_valor_inicial.Text),
                        valor_actual = double.Parse(txt_valor_inicial.Text)
                    };

                    CaixaBLL caixaBLL = new CaixaBLL();
                    caixaBLL.Cadastrar(Caixa);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HDATA PHARMACY",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
