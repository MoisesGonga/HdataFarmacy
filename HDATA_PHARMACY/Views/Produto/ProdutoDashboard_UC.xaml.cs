﻿using System;
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
    /// Interação lógica para ProdutoDashboard_UC.xam
    /// </summary>
    public partial class ProdutoDashboard_UC : UserControl
    {
        HomeWindow HomeWindow;
        public ProdutoDashboard_UC( HomeWindow HomeWindow)
        {
            InitializeComponent();
            this.HomeWindow = HomeWindow;
        }
       

        private void btn_add_produto_Click(object sender, RoutedEventArgs e)
        {
            this.HomeWindow.AbrirAdicionarProduto();
        }
    }
}
