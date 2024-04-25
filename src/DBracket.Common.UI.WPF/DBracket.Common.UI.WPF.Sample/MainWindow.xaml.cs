using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DBracket.Common.UI.WPF.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Task.Run(() =>
            {
                Test();
            });
        }

        private void Test()
        {
            var rnd = new Random();
            Task.Delay(1000).Wait();
            while (true)
            {
                //Application.Current.Dispatcher.Invoke(() => ColumnChart.DataPoint = new Charts.Data.ChartDataPoint(300));
                Application.Current.Dispatcher.Invoke(() => ColumnChart.DataPoint = new Charts.Data.ChartDataPoint(rnd.NextDouble() * 300));
                Task.Delay(1000).Wait();
            }
        }
    }
}