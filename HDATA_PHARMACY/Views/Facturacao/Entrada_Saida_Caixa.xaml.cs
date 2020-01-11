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
    /// Lógica interna para Entrada_Saida_Caixa.xaml
    /// </summary>
    public partial class Entrada_Saida_Caixa : Window
    {
        TipoOperacaoCaixa tipoOperacaoCaixa;
        public bool IsCaixaTurnOn { get; set; }
        public Entrada_Saida_Caixa()
        {
            InitializeComponent();
        }

        public Entrada_Saida_Caixa(TipoOperacaoCaixa tipoOperacao)
        {
            InitializeComponent();
            this.tipoOperacaoCaixa = tipoOperacao;
            CaixaBLL caixaBll = new CaixaBLL();

            if (HelperView.IsNotNull(caixaBll.ObterCaixaAberto(AppCommon.idUsuario)))
            {
                if (tipoOperacaoCaixa == TipoOperacaoCaixa.ENTRADA)
                {
                    lbl_descricao_operacao.Content = "Digite o valor de entrada:";
                    Title = "Entrada de Valor";
                }
                else if (tipoOperacaoCaixa == TipoOperacaoCaixa.SAIDA)
                {
                    lbl_descricao_operacao.Content = "Digite o valor de saída:";
                    Title = "Saída de Valor";
                }
                IsCaixaTurnOn = true;
            }
            else
            {
              //  MessageBox.Show("Atenção o caixa está fechado!", Properties.Settings.Default.MessageTitleMessageBox, MessageBoxButton.OK, MessageBoxImage.Warning);
                IsCaixaTurnOn = false;
            }
        }

        private void btn_salvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CaixaBLL caixaBll = new CaixaBLL();
                MovimentoCaixaBLL movimentoCaixaBll = new MovimentoCaixaBLL();
                var Caixa = caixaBll.ObterCaixaAberto(AppCommon.idUsuario);
                if (HelperView.IsNotNull(Caixa))
                {
                    if (tipoOperacaoCaixa == TipoOperacaoCaixa.ENTRADA)
                    {
                        movimento_caixa MovimentoCaixa = new movimento_caixa();
                        MovimentoCaixa.id_caixa = Caixa.id_caixa;
                        MovimentoCaixa.id_tipo_movimento = 1;
                        MovimentoCaixa.valor_movimento = double.Parse(txt_valor_movimento.Text);
                        MovimentoCaixa.descricao = txt_observacao.Text;
                        MovimentoCaixa.data_movimento = DateTime.Now;
                        movimentoCaixaBll.Cadastrar(MovimentoCaixa);
                    }
                    else if (tipoOperacaoCaixa == TipoOperacaoCaixa.SAIDA)
                    {
                         movimento_caixa MovimentoCaixa = new movimento_caixa();
                        MovimentoCaixa.id_caixa = Caixa.id_caixa;
                        MovimentoCaixa.id_tipo_movimento = 2;
                        MovimentoCaixa.valor_movimento = double.Parse(txt_valor_movimento.Text);
                        MovimentoCaixa.descricao = txt_observacao.Text;
                        MovimentoCaixa.data_movimento = DateTime.Now;
                        movimentoCaixaBll.Cadastrar(MovimentoCaixa);
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Atenção o caixa foi fechado!", Properties.Settings.Default.MessageTitleMessageBox, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao efectuar a operação de "+tipoOperacaoCaixa.ToString().ToLower());
            }
            
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
