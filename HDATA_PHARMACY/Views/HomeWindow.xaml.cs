using HDATA_PHARMACY.Views.Cliente;
using HDATA_PHARMACY.Views.Estoque;
using HDATA_PHARMACY.Views.Financa;
using HDATA_PHARMACY.Views.Produto;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HDATA_PHARMACY.Views
{
    /// <summary>
    /// Lógica interna para HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        object currentTabControl { get; set; }

        // Animacao Menu
        GridLength gridlength;
        public bool stateMenu { get; set; }
        DispatcherTimer dispacherTimer = new DispatcherTimer();

        public HomeWindow()
        {
            InitializeComponent();
            utilizadorExpander.Height = 0;

            // Animacao Menu
            dispacherTimer = new DispatcherTimer();
            stateMenu = true;
            dispacherTimer.Tick += new EventHandler(timer_tick);
            dispacherTimer.Interval = new TimeSpan(0, 0, 0, 0, 0);

            TabItem tabItem = mainTabControl.Items[0] as TabItem;
            FinancaDashboard_UC EntradaDashboard_ = new FinancaDashboard_UC();
            tabItem.Content = EntradaDashboard_;
           // Add_item_main_tab_Control(tabItem);
        }

        #region AnimacaoBarraMenu

       
        // Animacao Menu
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                dispacherTimer.Start();
            }
        }

        #endregion

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            utilizadorExpander.Height = 145;
        }

        private void btn_perfil_Click(object sender, RoutedEventArgs e)
        {
            if (utilizadorExpander.IsExpanded == true)
            {
                utilizadorExpander.IsExpanded = false;
                utilizadorExpander.Height = 0;

            }
            else
            {
                utilizadorExpander.Height = 145;
                utilizadorExpander.IsExpanded = true;
            }

        }

        public void Add_item_main_tab_Control(object tabItem)
        {
            this.currentTabControl = tabItem;
            Thread thread = new Thread(AddCurrentTabControl);
            thread.Start();
        }

        private void AddCurrentTabControl()
        {
            this.Dispatcher.InvokeAsync(new Action(() =>
            {
                this.mainTabControl.Items.Add(currentTabControl);
                mainTabControl.SelectedItem = currentTabControl;
                currentTabControl = null;
            }));
        }

       

        private void ReceitaSubMenu_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = "Receita    ";
            FinancaEntradaDashboard_UC EntradaDashboard_ = new FinancaEntradaDashboard_UC();
            tabItem.Content = EntradaDashboard_;
            Add_item_main_tab_Control(tabItem);
        }

        private void Trv_Cliente_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = "Cliente    ";
            ClienteDashboard_UC clienteDashboard_ = new ClienteDashboard_UC();
            tabItem.Content = clienteDashboard_;
            Add_item_main_tab_Control(tabItem);
        }
        public void AbrirAdicionarProduto()
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = "Produto Adiconar   ";
            ProdutoAdicionar_UC produtoDashboard_ = new ProdutoAdicionar_UC();
            tabItem.Content = produtoDashboard_;
            Add_item_main_tab_Control(tabItem);
        }
        public void AbrirAdicionarLote()
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = "Lote Adicionar   ";
            LoteAdicionar_UC produtoDashboard_ = new LoteAdicionar_UC();
            tabItem.Content = produtoDashboard_;
            Add_item_main_tab_Control(tabItem);
        }

        public void AbrirAdicionarMovimento()
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = "Movimento Adicionar   ";
            MovimentoEstoqueAdicionar_UC produtoDashboard_ = new MovimentoEstoqueAdicionar_UC();
            tabItem.Content = produtoDashboard_;
            Add_item_main_tab_Control(tabItem);
        }

        public void AbrirAdicionarProdtoEstoqe()
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = "Estoque Adicionar Novo Produto  ";
            EstoqueAdicionar_UC produtoDashboard_ = new EstoqueAdicionar_UC();
            tabItem.Content = produtoDashboard_;
            Add_item_main_tab_Control(tabItem);
        }
        private void Trv_Produto_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = "Produto    ";
            ProdutoDashboard_UC produtoDashboard_ = new ProdutoDashboard_UC( this);
            tabItem.Content = produtoDashboard_;
            Add_item_main_tab_Control(tabItem);
        }

        private void Trv_Lote_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = "Lote    ";
            LoteDashboard_UC produtoDashboard_ = new LoteDashboard_UC(this);
            tabItem.Content = produtoDashboard_;
            Add_item_main_tab_Control(tabItem);
        }

        private void Trv_Estoque_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = "Estoque    ";
            EstoqueDashboard_UC produtoDashboard_ = new EstoqueDashboard_UC(this);
            tabItem.Content = produtoDashboard_;
            Add_item_main_tab_Control(tabItem);
        }

        private void TreeViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = "Movimento    ";
            MovimentosEstoqueDashboard_UC produtoDashboard_ = new MovimentosEstoqueDashboard_UC(this);
            tabItem.Content = produtoDashboard_;
            Add_item_main_tab_Control(tabItem);
        }
    }
}
