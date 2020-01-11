using BLL;
using HDATA_PHARMACY.Extras;
using HDATA_PHARMACY.Security;
using HDATA_PHARMACY.Views.Estoque;
using HDATA_PHARMACY.Views.Fornecedor;
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

namespace HDATA_PHARMACY.Views.Produto
{
    /// <summary>
    /// Interaction logic for LoteAdicionar_UC.xaml
    /// </summary>
    public partial class LoteAdicionar_UC : UserControl
    {
        produto ProdutoSeleccionado;
        lote LoteSeleccionado;
        public LoteAdicionar_UC()
        {
            InitializeComponent();
            CarregarDados();
            this.Cmb_Produto.IsEnabled = false;
            
        }
        public void CarregarDados()
        {

            CarregarFornecedor();
            CarregarApresentacaoProduto();
            CarregarProduto();
            CarregarLocalEstoque();



        }

        public void CarregarFornecedor()
        {

            FornecedorBLL condicaoPagamentoBll = new FornecedorBLL();
            Cmb_Fornecedor.DisplayMemberPath = "nome";
            Cmb_Fornecedor.ItemsSource = null;
            Cmb_Fornecedor.ItemsSource = condicaoPagamentoBll.Listar();

        }


        public void CarregarProduto()
        {

            ProdutoBLL condicaoPagamentoBll = new ProdutoBLL();
            Cmb_Produto.DisplayMemberPath = "nome";
            Cmb_Produto.ItemsSource = null;
            Cmb_Produto.ItemsSource = condicaoPagamentoBll.Listar();

        }

        public void CarregarApresentacaoProduto()
        {

            ApresentacaoProdutoBLL condicaoPagamentoBll = new ApresentacaoProdutoBLL();
            Cmb_ApresentacaoProduto.DisplayMemberPath = "nome";
            Cmb_ApresentacaoProduto.ItemsSource = null;
            Cmb_ApresentacaoProduto.ItemsSource = condicaoPagamentoBll.Listar();

        }
        private void btn_novo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void salvar()
        {
            lote NovoLote = new lote();
            NovoLote.fornecedor = Cmb_Fornecedor.SelectedItem as fornecedor;
            NovoLote.produto = ProdutoSeleccionado as produto;
            NovoLote.descricao = TxtDescricao.Text;
            NovoLote.data_validade = data_Validade.SelectedDate.Value;
            NovoLote.codigo_barra = TxtCodigoBarra.Text;
            NovoLote.data_alteracao = DateTime.Now;
            NovoLote.data_cadastro = DateTime.Now;
            NovoLote.apresentacao_produto = Cmb_ApresentacaoProduto.SelectedItem as apresentacao_produto;
            NovoLote.info_lote = TxtInfoLote.Text;
            NovoLote.preco_compra = float.Parse(TxtPrecoCompra.Text);
            NovoLote.margem_venda = float.Parse(TxtMargemVenda.Text);
            NovoLote.preco_venda = float.Parse(TxtPrecoVenda.Text);

            LoteBLL LoteBLL = new LoteBLL();
            LoteSeleccionado = LoteBLL.Cadastrar(NovoLote);
           /* MessageBox.Show(lotecad.id_lote.ToString());
            LoteSeleccionado = LoteBLL.ObterPeloId(  LoteBLL.FindMaxId(LoteBLL.Listar()));
            MessageBox.Show("manobra "+LoteSeleccionado.id_lote.ToString());
            */
        }

        private void btn_salvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                salvar();
                SalvarEstoque();
                SalvarMovimento();
                MessageBox.Show("salvo");

            }
            catch (Exception)
            {

                MessageBox.Show("erro ao salvar");
            }

           

        }

        private void btn_Local_Click(object sender, RoutedEventArgs e)
        {
            SearchContent_Window window = new SearchContent_Window();

            LocalEstoqueAdicionar_UC listaUC = new LocalEstoqueAdicionar_UC(this);
            window.Title = "Adicionar de Local Estoque";
            window.Content = listaUC;
            window.ShowDialog();
        }
        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Disciplina_Click(object sender, RoutedEventArgs e)
        {
            SearchContent_Window window = new SearchContent_Window();
            ApresentacaoProdutoAdicionar_UC listaUC = new ApresentacaoProdutoAdicionar_UC(this);
            window.Title = "Adicionar de Apresentação  Produto";
            window.Content = listaUC;
            window.ShowDialog();
        }

      

        private void btn_Fornecedor_Click(object sender, RoutedEventArgs e)
        {
            SearchContent_Window window = new SearchContent_Window();
            
                
             FornecedorAdicionar_UC   listaUC = new FornecedorAdicionar_UC(this);
            window.Title = "Adicionar de Fornecedor";
            window.Content = listaUC;
            window.ShowDialog();
        }

        private void btn_Produto_Click(object sender, RoutedEventArgs e)
        {
            /*SearchContent_Window window = new SearchContent_Window();


            ProdutoAdicionar_UC listaUC = new ProdutoAdicionar_UC(this);
            window.Title = "Adicionar de Produto";
            window.Content = listaUC;
            window.ShowDialog();
            */

            SearchContent_Window window = new SearchContent_Window();
            ListaProduto_UC listaUC = new ListaProduto_UC(window, this);
            window.Title = "Consulta de Produtos";
            window.Content = listaUC;
            window.ShowDialog();


        }
        public void SeleccionarProduto(produto Produto)
        {
            this.ProdutoSeleccionado = Produto;
            Cmb_Produto.Text = ProdutoSeleccionado.nome;
            //MessageBox.Show(ProdutoSeleccionado.nome);
            
        }
        public void CarregarLocalEstoque()
        {
            LocalEstoqueBLL condicaoPagamentoBll = new LocalEstoqueBLL();
            Cmb_LocalEstoque.DisplayMemberPath = "descricao";
            Cmb_LocalEstoque.ItemsSource = null;
            Cmb_LocalEstoque.ItemsSource = condicaoPagamentoBll.Listar();

        }
        private void TxtMargemVenda_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularPrecoVenda();
        }
       private void CalcularPrecoVenda() {

            try
            {
                if (!TxtPrecoCompra.Text.Equals("") && !TxtMargemVenda.Text.Equals(""))
                {
                    float preco_compra = float.Parse(TxtPrecoCompra.Text);
                    float margem_venda = float.Parse(TxtMargemVenda.Text);


                    float preco_venda = preco_compra + preco_compra * margem_venda / 100;
                    TxtPrecoVenda.Text = preco_venda.ToString();

                    //float.Parse(TxtPrecoVenda.Text);

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void TxtPrecoVenda_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularMargemVenda();
        }

        private void SalvarMovimento()
        {
            movimento_estoque novo = new movimento_estoque();
            novo.data = DateTime.Now;
            novo.data_compra = data_compra.SelectedDate;
            novo.ajuste = 0;
            novo.descricao = "Primeira Inserção";

            novo.id_local_estoque = (Cmb_LocalEstoque.SelectedItem as local_estoque).id_local_estoque;
            novo.id_lote = LoteSeleccionado.id_lote;
            novo.id_produto = LoteSeleccionado.id_produto;
            novo.id_tipo_movimento = 1;
            novo.id_utilizador = 1;//AppCommon.idUsuario;
            novo.preco_compra = float.Parse( LoteSeleccionado.preco_compra.ToString());
            novo.qtd = Convert.ToInt32(TxtQtdActaal.Text);


            MovimentoEstoqueBLL MovimentoEstoqueBLL = new MovimentoEstoqueBLL();
            MovimentoEstoqueBLL.Cadastrar(novo);

        }
        private void SalvarEstoque()
        {
            estoque_produto novo = new estoque_produto();

            novo.lote = LoteSeleccionado as lote;
            novo.id_lote = LoteSeleccionado.id_lote;
            novo.local_estoque = Cmb_LocalEstoque.SelectedItem as local_estoque;
            novo.id_local_estoque = novo.local_estoque.id_local_estoque;
            novo.id_produto = LoteSeleccionado.id_produto;
            novo.data_criacao = DateTime.Now;
            novo.qtd_encomenda = Convert.ToInt32(TxtQtdMaxima.Text);
            //Devemos  colocar o id do usuario real 

            novo.id_user = 1;
            novo.qtd_minima = Convert.ToInt32(TxtQtdMinimaa.Text);
            novo.qtd_existente = Convert.ToInt32(TxtQtdActaal.Text);
            novo.preco_venda = (float)(LoteSeleccionado.preco_venda);

            EstoqueProdutoBLL EstoqueProdutoBLL = new EstoqueProdutoBLL();
            EstoqueProdutoBLL.Cadastrar(novo);

        }

        private void CalcularMargemVenda()
        {

            try
            {
                if (!TxtPrecoCompra.Text.Equals("") && !TxtPrecoVenda.Text.Equals(""))
                {
                    float preco_compra = float.Parse(TxtPrecoCompra.Text);
                    float preco_venda = float.Parse(TxtPrecoVenda.Text);


                    float margem = ((preco_venda - preco_compra) / preco_compra) * 100;
                    TxtMargemVenda.Text = margem.ToString();

                    //float.Parse(TxtPrecoVenda.Text);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
