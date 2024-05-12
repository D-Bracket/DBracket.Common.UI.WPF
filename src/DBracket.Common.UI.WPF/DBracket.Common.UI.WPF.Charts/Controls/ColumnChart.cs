using DBracket.Common.UI.WPF.Charts.Controls.Components;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

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

            SizeChanged += HandleSizeChanged;
            Loaded += HandleLoaded;

            //HorizontalGrid.Add("s");
            //HorizontalGrid.Add("s");
            //HorizontalGrid.Add("s");
            //HorizontalGrid.Add("s");
            //HorizontalGrid.Add("s");
            //HorizontalGrid.Add("s");
            //HorizontalGrid.Add("s");
        }

        private void HandleLoaded(object sender, RoutedEventArgs e)
        {
            var chart = sender as ColumnChart;
            if (chart is null)
                return;

            for (int i = 0; i < chart.Columns.Count; i++)
            {
                chart.Columns[i].ColumnNr = i;
            }
        }

        private void HandleSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width != e.PreviousSize.Width)
            {
                // Handle Width Changed
            }

            if (e.NewSize.Height != e.PreviousSize.Height)
            {
                // Handle Height Changed
                var height = e.NewSize.Height - 20;
                var t = 0.0;
                int lines = (int)height / 50;
                HorizontalGrid.Clear();
                for (int i = 0; i < lines; i++)
                {
                    HorizontalGrid.Add("s");
                }

            }
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"
        //private async static void UpdatePoints(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var chart = d as ColumnChart;
        //    if (chart is null)
        //        return;

        //    chart.DataPoints.CollectionChanged += (s, e) =>
        //    {
        //        var pointCollection = s as ObservableCollection<ChartDataPoint>;
        //        if (pointCollection is null)
        //            return;

        //        foreach (var point in pointCollection)
        //        {
        //            //point.PropertyChanged += (s, e) =>
        //            //{
        //            PointAnimation animation = new PointAnimation(new System.Windows.Point(0, -chart.DataPoints[0].Value), new TimeSpan(0, 0, 0, 0, 400));
        //            chart.BeginAnimation(Point1Property, animation);
        //            PointAnimation animation2 = new PointAnimation(new System.Windows.Point(50, -chart.DataPoints[0].Value), new TimeSpan(0, 0, 0, 0, 400));
        //            chart.BeginAnimation(Point2Property, animation2);


        //            //};
        //        }

        //    };
        //}
        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public ObservableCollection<Column> Columns
        {
            get => (ObservableCollection<Column>)GetValue(ColumnsProperty);
            set => SetValue(ColumnsProperty, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register(
            "Columns", typeof(ObservableCollection<Column>), typeof(ColumnChart), new FrameworkPropertyMetadata(new ObservableCollection<Column>(), HandleColumnsChanged));

        private static void HandleColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var chart = (ColumnChart)d;
            chart.Columns.CollectionChanged += HandleColumnsChanged;
        }

        private static void HandleColumnsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            // Resize columns
            if (e.NewItems is null)
                return;

            foreach (var column in e.NewItems)
            {

            }


        }

        public AxisTest YAxis
        {
            get => (AxisTest)GetValue(YAxisProperty);
            set => SetValue(YAxisProperty, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty YAxisProperty = DependencyProperty.Register(
            "YAxis", typeof(AxisTest), typeof(ColumnChart), new FrameworkPropertyMetadata(null));






        public ObservableCollection<string> HorizontalGrid
        {
            get => (ObservableCollection<string>)GetValue(HorizontalGridProperty);
            set => SetValue(HorizontalGridProperty, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty HorizontalGridProperty = DependencyProperty.Register(
            "HorizontalGrid", typeof(ObservableCollection<string>), typeof(ColumnChart), new FrameworkPropertyMetadata(new ObservableCollection<string>()));
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}