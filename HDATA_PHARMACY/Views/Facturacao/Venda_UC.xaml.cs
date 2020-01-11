using BLL;
using Dragablz;
using DTO.Model;
using HDATA_PHARMACY.Extras;
using HDATA_PHARMACY.Views.Cliente;
using HDATA_PHARMACY.Views.Produto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HDATA_PHARMACY.Views.Facturacao
{
    /// <summary>
    /// Interação lógica para Venda_UC.xam
    /// </summary>
    public partial class Venda_UC : UserControl
    {
        TipoManipulacao tipoManipulacao = TipoManipulacao.CREATE;
        cliente ClienteSelecionado;
        produto ProdutoSelecionado;
        ObservableCollection<ProdutoItemVenda> ListaProdutoFacturacao;
        POS_Window pos_Window;
        ProdutoBLL produtoBLL = new ProdutoBLL();


        public Venda_UC()
        {
            InitializeComponent();
            CarregarDados();
            NovaVenda();
        }

        public Venda_UC(POS_Window pos_Window)
        {
            InitializeComponent();
            CarregarDados();
            NovaVenda();
            this.pos_Window = pos_Window;
        }

        private void CarregarDados()
        {
            CarregarCondicaoPagamento();
            CarregarTipoDocVenda();
            data_facturacao.SelectedDate = DateTime.Now;
        }

        private void CarregarCondicaoPagamento()
        {
            TipoUnidadeBLL condicaoPagamentoBll = new TipoUnidadeBLL();
            cmb_condicoes_pagamento.DisplayMemberPath = "nome";
            cmb_condicoes_pagamento.ItemsSource = null;
            cmb_condicoes_pagamento.ItemsSource = condicaoPagamentoBll.Listar();
        }

        private void CarregarTipoDocVenda()
        {
            TipoDocVendaBLL tipoDocVendaBLL = new TipoDocVendaBLL();
            cmb_documento_facturacao.DisplayMemberPath = "nome";
            cmb_documento_facturacao.ItemsSource = null;
            cmb_documento_facturacao.ItemsSource = tipoDocVendaBLL.Listar();
        }

        private void btn_salvar_Click(object sender, RoutedEventArgs e)
        {
            
            FinalizarVendaWindow f = new FinalizarVendaWindow();
            f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            f.ShowDialog();

        }

        private void btn_consultarProduto_Click(object sender, RoutedEventArgs e)
        {
            ConsultarProduto();
        }

        private void txt_cliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.F4))
            {
                ConsultarCliente();
            }
            
        }

        private void btnConsultarCliente_Click(object sender, RoutedEventArgs e)
        {
            ConsultarCliente();
        }

        private void ConsultarProduto()
        {
            SearchContent_Window window = new SearchContent_Window();
            ListaProduto_UC listaUC = new ListaProduto_UC(window);
            window.Title = "Consulta de Produtos";
            window.Content = listaUC;
            window.ShowDialog();
            ProdutoSelecionado = listaUC.SeleccionarProduto();
            if (HelperView.IsNotNull(ProdutoSelecionado))
                CarregarProduto(ProdutoSelecionado);
        }

        private void ConsultarCliente()
        {
            SearchContent_Window window = new SearchContent_Window();
            ListaCliente_UC listaUC = new ListaCliente_UC(window);
            window.Title = "Consulta de Clientes";
            window.Content = listaUC;
            window.ShowDialog();
            CarregarCliente(listaUC.SeleccionarCliente());
        }

        private void txt_codigo_produto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.F4))
            {
                ConsultarProduto();
            }
            
                if (e.Key.Equals(Key.Enter))
            {
                lote Lote = produtoBLL.ObterLotePeloCodBarras(txt_codigo_produto.Text);
                if (HelperView.IsNotNull(Lote))
                {
                    CarregarProduto(Lote.produto);
                }
                else
                {
                    try
                    {
                        int idProduto = int.Parse(txt_codigo_produto.Text);
                        var Produto = produtoBLL.ObterPeloId(idProduto);
                        if (HelperView.IsNotNull(Produto))
                        {
                            CarregarProduto(Produto);
                        }
                        else
                        {
                            MessageBox.Show("O código informado não foi encontrado!", Properties.Settings.Default.MessageTitleMessageBox, MessageBoxButton.OK, MessageBoxImage.Warning);
                            CarregarProduto(null);
                        }
                        
                    }
                    catch (Exception)
                    {
                            MessageBox.Show("O código informado não foi encontrado!", Properties.Settings.Default.MessageTitleMessageBox, MessageBoxButton.OK, MessageBoxImage.Warning);
                            CarregarProduto(null);
                    }
                    
                }
                    
            }
        }

        private void NovaVenda()
        {
            tipoManipulacao = TipoManipulacao.CREATE;
            checkBox_Cliente.IsChecked = true;
            ListaProdutoFacturacao = new ObservableCollection<ProdutoItemVenda>();
        }

        private void checkBox_Cliente_Checked(object sender, RoutedEventArgs e)
        {
            btnConsultarCliente.IsEnabled = txt_cliente.IsEnabled = false;
            CarregarClienteDiverso();
        }

        private void checkBox_Cliente_Unchecked(object sender, RoutedEventArgs e)
        {
            btnConsultarCliente.IsEnabled = txt_cliente.IsEnabled = true;
        }

        private void btn_novo_Click(object sender, RoutedEventArgs e)
        {
            NovaVenda();
        }

        private void CarregarCliente(cliente Cliente)
        {
            if (HelperView.IsNotNull(Cliente))
            {
                ClienteSelecionado = Cliente;
                txt_cliente.Text = ClienteSelecionado.nome;
            }
        }

        private void CarregarProduto(produto Produto)
        {
            
            if (HelperView.IsNotNull(Produto))
            {
                ProdutoSelecionado = Produto;
                txt_codigo_produto.Text = Produto.id_produto+"";
                txt_descricao_produto_servico.Text = Produto.nome;
                txt_QuantProduto.Value  = 1;
            }
            else
            {
                ProdutoSelecionado = null;
                txt_codigo_produto.Text = string.Empty;
                txt_descricao_produto_servico.Text = string.Empty;
                txt_QuantProduto.Value = 1;
            }
        }

        private void CarregarClienteDiverso()
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            var Cliente = clienteBLL.ClienteDiverso();
            if (HelperView.IsNotNull(Cliente))
            {
                ClienteSelecionado = Cliente;
                txt_cliente.Text = ClienteSelecionado.nome;
            }
        }

        private void AddListaVenda(ProdutoItemVenda produtoItemVenda)
        {
            ListaProdutoFacturacao.Add(produtoItemVenda);
            CarregarListaVenda();
        }

        private void btnRemoverProduto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddProduto_Click(object sender, RoutedEventArgs e)
        {
            if (HelperView.IsNotNull(ProdutoSelecionado))
            {
                if (ListaProdutoFacturacao.Where(t=>t.CodigoBarra.Equals(ProdutoSelecionado.id_categoria)).Count()>0)
                    MessageBox.Show("O produto seleccionado já foi adicionado!", Properties.Settings.Default.MessageTitleMessageBox, MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                {
                    ProdutoItemVenda item = new ProdutoItemVenda();
                    lote Lote;
                    item.Descricao = ProdutoSelecionado.descricao;
                    item.Unidade = item.Produto.tipo_unidade.abreviatura;
                    item.CodigoBarra = ProdutoSelecionado.codigo_barra;
                    if (item.Produto.disciplina_estoque.codigo_disciplina == 1)
                        Lote = produtoBLL.ObterLoteRecenteProduto(item.Produto.id_produto);
                    else if(item.Produto.disciplina_estoque.codigo_disciplina == 2)
                        Lote = produtoBLL.ObterLoteAntigoProduto(item.Produto.id_produto);
                    else
                        Lote = produtoBLL.ObterLoteRecenteProduto(item.Produto.id_produto);

                    if (HelperView.IsNotNull(Lote))
                    {
                        item.Produto = Lote.produto;
                        item.Lote = Lote.info_lote;
                        if (Lote.preco_venda.HasValue)
                            item.PrecoUnit = Lote.preco_venda.Value;
                        item.Validade = Lote.data_validade;
                    }
                    AddListaVenda(item);
                    //ListaProdutoFacturacao.Add(item);
                }
            }
        }

        private void txt_codigo_produto_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.txt_codigo_produto.Text.Trim() == string.Empty)
            {
                txt_codigo_produto.Text = "";
                txt_descricao_produto_servico.Text = "";
                txt_QuantProduto.Value = 1;
            }
        }

        public void CarregarListaVenda()
        {
            datagrid_venda.ItemsSource = null;
            datagrid_venda.ItemsSource = ListaProdutoFacturacao;
        }

    }
    
}
