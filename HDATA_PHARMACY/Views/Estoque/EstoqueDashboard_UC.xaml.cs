using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
    /// Interaction logic for EstoqueDashboard_UC.xaml
    /// </summary>
    public partial class EstoqueDashboard_UC : UserControl
    {
        public Func<ChartPoint, string> PointLabel { get; set; }
        public ChartValues<ObservableValue> MyValues { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection Series { get; set; }

        HomeWindow HomeWindow;

        public EstoqueDashboard_UC(HomeWindow HomeWindow)
        {
            this.HomeWindow =HomeWindow;
            InitializeComponent();

            MyValues = new ChartValues<ObservableValue>
            {
                new ObservableValue(5),
                new ObservableValue(7),
                new ObservableValue(8),
                new ObservableValue(3)
            };

            var lineSeries = new LineSeries
            {
                Values = MyValues,
                StrokeThickness = 4,
                Fill = Brushes.Transparent,
                PointGeometrySize = 0,
                DataLabels = true
            };

            MyValues = new ChartValues<ObservableValue>
            {
                new ObservableValue(7),
                new ObservableValue(1),
                new ObservableValue(9),
                new ObservableValue(6)
            };

            var lineSeries1 = new LineSeries
            {
                Values = MyValues,
                StrokeThickness = 4,
                Fill = Brushes.Transparent,
                PointGeometrySize = 0,
                DataLabels = true
            };

            MyValues = new ChartValues<ObservableValue>
            {
                new ObservableValue(2),
                new ObservableValue(10),
                new ObservableValue(4),
                new ObservableValue(9)
            };

            var lineSeries3 = new LineSeries
            {
                Values = MyValues,
                StrokeThickness = 4,
                Fill = Brushes.Transparent,
                PointGeometrySize = 0,
                DataLabels = true
            };


            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            SeriesCollection = new SeriesCollection { lineSeries, lineSeries1, lineSeries3 };


            DataContext = this;

        }
        public EstoqueDashboard_UC()
        {
            InitializeComponent();

            MyValues = new ChartValues<ObservableValue>
            {
                new ObservableValue(5),
                new ObservableValue(7),
                new ObservableValue(8),
                new ObservableValue(3)
            };

            var lineSeries = new LineSeries
            {
                Values = MyValues,
                StrokeThickness = 4,
                Fill = Brushes.Transparent,
                PointGeometrySize = 0,
                DataLabels = true
            };

            MyValues = new ChartValues<ObservableValue>
            {
                new ObservableValue(7),
                new ObservableValue(1),
                new ObservableValue(9),
                new ObservableValue(6)
            };

            var lineSeries1 = new LineSeries
            {
                Values = MyValues,
                StrokeThickness = 4,
                Fill = Brushes.Transparent,
                PointGeometrySize = 0,
                DataLabels = true
            };

            MyValues = new ChartValues<ObservableValue>
            {
                new ObservableValue(2),
                new ObservableValue(10),
                new ObservableValue(4),
                new ObservableValue(9)
            };

            var lineSeries3 = new LineSeries
            {
                Values = MyValues,
                StrokeThickness = 4,
                Fill = Brushes.Transparent,
                PointGeometrySize = 0,
                DataLabels = true
            };


            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            SeriesCollection = new SeriesCollection { lineSeries, lineSeries1, lineSeries3 };


            DataContext = this;

        }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.HomeWindow.AbrirAdicionarProdtoEstoqe();
        }
    }
}
