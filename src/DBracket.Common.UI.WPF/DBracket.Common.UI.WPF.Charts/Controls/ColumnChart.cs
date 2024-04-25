using DBracket.Common.UI.WPF.Charts.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Printing.IndexedProperties;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace DBracket.Common.UI.WPF.Charts.Controls
{
    public class ColumnChart : Control
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public ColumnChart()
        {
            //Task.Run(() =>
            //{
            //    UpdateChart();
            //});

            HorizontalGrid.Add("s");
            HorizontalGrid.Add("s");
            HorizontalGrid.Add("s");
            HorizontalGrid.Add("s");
            HorizontalGrid.Add("s");
            HorizontalGrid.Add("s");
            HorizontalGrid.Add("s");
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"
        private void UpdateChart()
        {
            //while (true)
            //{
            Point1 = new Point(-DataPoint.Value, 0);
            Point2 = new Point(-DataPoint.Value, 50);
            //    Task.Delay(100).Wait();
            //}
        }
        #endregion

        #region "------------------------------ Event Handling -----------------------------"
        private async static void UpdatePoints(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var chart = d as ColumnChart;
            if (chart is not null)
            {
                PointAnimation animation = new PointAnimation(new Point(0, -chart.DataPoint.Value), new TimeSpan(0, 0, 0, 0, 400));
                chart.BeginAnimation(Point1Property, animation);
                PointAnimation animation2 = new PointAnimation(new Point(50, -chart.DataPoint.Value), new TimeSpan(0, 0, 0, 0, 400));
                chart.BeginAnimation(Point2Property, animation2);








                //var index = 500;
                //var step = chart.DataPoint.Value / index;
                //var val = 0.0;
                //while (true)
                //{

                //    val += step;
                //    chart.Point1 = new Point(0, -val);
                //    chart.Point2 = new Point(50, -val);
                //    await Task.Delay(1);
                //    index--;
                //    if (index == 0)
                //        break;
                //}






                //chart.Point1 = new Point(0,-chart.DataPoint.Value);
                //chart.Point1 = new Point(-chart.DataPoint.Value,50);
                //chart.Point1 = new Point(0, -50);
                //chart.Point1 = new Point(-chart.DataPoint.Value, 50);

                //chart.DataPoint.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler ((object? sender, PropertyChangedEventArgs e) =>
                //{

                //});
            }
        }
        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public ObservableCollection<string> HorizontalGrid
        {
            get => (ObservableCollection<string>)GetValue(HorizontalGridProperty);
            set => SetValue(HorizontalGridProperty, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty HorizontalGridProperty = DependencyProperty.Register(
            "HorizontalGrid", typeof(ObservableCollection<string>), typeof(ColumnChart), new FrameworkPropertyMetadata(new ObservableCollection<string>()));

        public ChartDataPoint DataPoint
        {
            get => (ChartDataPoint)GetValue(DataPointProperty);
            set => SetValue(DataPointProperty, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty DataPointProperty = DependencyProperty.Register(
            "DataPoint", typeof(ChartDataPoint), typeof(ColumnChart), new FrameworkPropertyMetadata(null, UpdatePoints));



        public Point Point1
        {
            get => (Point)GetValue(Point1Property);
            set => SetValue(Point1Property, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty Point1Property = DependencyProperty.Register(
            "Point1", typeof(Point), typeof(ColumnChart), new FrameworkPropertyMetadata(new Point()));

        public Point Point2
        {
            get => (Point)GetValue(Point2Property);
            set => SetValue(Point2Property, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty Point2Property = DependencyProperty.Register(
            "Point2", typeof(Point), typeof(ColumnChart), new FrameworkPropertyMetadata(new Point(50, 0)));
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}