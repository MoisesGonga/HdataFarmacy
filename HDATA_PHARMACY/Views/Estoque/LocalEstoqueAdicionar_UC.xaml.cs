using BLL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HDATA_PHARMACY.Views.Estoque
{
    /// <summary>
    /// Interaction logic for LocalEstoqueAdicionar_UC.xaml
    /// </summary>
    public partial class LocalEstoqueAdicionar_UC : UserControl
    {
        EstoqueAdicionar_UC EstoqueAdicionar_UC;
        LoteAdicionar_UC LoteAdicionar_UC;
        MovimentoEstoqueAdicionar_UC MovimentoEstoqueAdicionar_UC;
        public LocalEstoqueAdicionar_UC()
        {
            InitializeComponent();
        }

        public LocalEstoqueAdicionar_UC(EstoqueAdicionar_UC EstoqueAdicionar_UC)
        {
            InitializeComponent();
            this.EstoqueAdicionar_UC = EstoqueAdicionar_UC;
        }
        public LocalEstoqueAdicionar_UC(MovimentoEstoqueAdicionar_UC MovimentoEstoqueAdicionar_UC)
        {
            InitializeComponent();
            this.MovimentoEstoqueAdicionar_UC = MovimentoEstoqueAdicionar_UC;
        }
        public LocalEstoqueAdicionar_UC(LoteAdicionar_UC LoteAdicionar_UC)
        {
            InitializeComponent();
            this.LoteAdicionar_UC = LoteAdicionar_UC;
        }
        private void btn_salvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Salvar();
                if (EstoqueAdicionar_UC!=null)
                {
                    EstoqueAdicionar_UC.CarregarLocalEstoque();
                }
                else if (LoteAdicionar_UC!= null)
                {
                    LoteAdicionar_UC.CarregarLocalEstoque();
                }
                else if (MovimentoEstoqueAdicionar_UC != null)
                {
                    MovimentoEstoqueAdicionar_UC.CarregarLocalEstoque();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Salvar()
        {
            String Descricao=TxtDescricao.Text;
            String Endereco=TxtEndereco.Text;
            String operacao=TxtOperacao.Text;
            local_estoque NovoLocal = new local_estoque();
            NovoLocal.descricao = Descricao;
            NovoLocal.endereco = Endereco;
            NovoLocal.operacao = operacao;

            LocalEstoqueBLL LocalEstoqueBLL = new LocalEstoqueBLL();
            LocalEstoqueBLL.Cadastrar(NovoLocal);
            MessageBox.Show("Salvo com sucesso");



        }
    }
}
